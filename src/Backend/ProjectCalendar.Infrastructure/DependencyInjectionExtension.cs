using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using ProjectCalendar.Domain.Interfaces;
using ProjectCalendar.Infrastructure.DataAccess;

namespace ProjectCalendar.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEventRepository, EventRepository>();

            return services;
        }
    }
}
