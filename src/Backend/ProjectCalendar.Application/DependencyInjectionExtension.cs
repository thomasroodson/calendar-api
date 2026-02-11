using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProjectCalendar.Application.UseCases.Event.GetById;
using ProjectCalendar.Application.UseCases.Event.GetAll;
using ProjectCalendar.Application.UseCases.Event.Register;
using System.Reflection;
using ProjectCalendar.Application.UseCases.Event.GetByDate;
using ProjectCalendar.Communication.Requests;
using ProjectCalendar.Application.UseCases.Event.Update;
using ProjectCalendar.Application.UseCases.Event.Delete;

namespace ProjectCalendar.Application
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // UseCases
            services.AddScoped<IRegisterEventUseCase, RegisterEventUseCase>();
            services.AddScoped<IGetAllEventsUseCase, GetAllEventsUseCase>();
            services.AddScoped<IGetEventByIdUseCase, GetEventByIdUseCase>();
            services.AddScoped<IGetEventsByDateUseCase, GetEventsByDateUseCase>();
            services.AddScoped<IUpdateEventUseCase, UpdateEventUseCase>();
            services.AddScoped<IDeleteEventUseCase, DeleteEventUseCase>();


            // Validators
            services.AddScoped<IValidator<RequestRegisterEventJson>, RegisterEventValidator>();
            services.AddScoped<IValidator<string>, GetEventByIdValidator>();
            services.AddScoped<IValidator<RequestGetEventByDateJson>, GetEventByDateValidator>();
            services.AddScoped<IValidator<RequestUpdateEventJson>, UpdateEventValidator>();
            services.AddScoped<IValidator<string>, DeleteEventValidator>();

            return services;
        }
    }
}
