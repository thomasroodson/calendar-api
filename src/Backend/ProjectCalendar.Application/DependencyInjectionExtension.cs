using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProjectCalendar.Application.UseCases.Event.GetById;
using ProjectCalendar.Application.UseCases.Event.GetAll;
using ProjectCalendar.Application.UseCases.Event.Register;
using System.Reflection;
using ProjectCalendar.Application.UseCases.Event.GetByDate;

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


            return services;
        }
    }
}
