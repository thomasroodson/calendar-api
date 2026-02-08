using Mapster;
using MapsterMapper;
using MongoDB.Driver;
using ProjectCalendar.API.Filters;
using ProjectCalendar.API.Middleware;
using ProjectCalendar.Application;
using ProjectCalendar.Infrastructure;
using ProjectCalendar.Infrastructure.DataAccess;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

MongoDbConfiguration.Configure();

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration["MongoDbSettings:ConnectionString"];
    return new MongoClient(connectionString);
});

builder.Services.AddScoped<MongoDbContext>();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApplication();

// Registrar Mapster
var config = TypeAdapterConfig.GlobalSettings;
config.Scan(Assembly.GetExecutingAssembly());
config.Scan(Assembly.Load("ProjectCalendar.Application"));

builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

// Registrar Controllers com ExceptionFilter
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ExceptionFilter));
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Calendar API",
        Version = "v1",
        Description = "API para gerenciamento de eventos de calendário"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocumentTitle = "Calendar API - V1";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calendar API - V1");
    });
}

app.UseMiddleware<CultureMiddleware>();

app.UseNotFoundHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();