using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProjectCalendar.Application.UseCases.Event.Get;
using ProjectCalendar.Application.UseCases.Event.GetAll;
using ProjectCalendar.Application.UseCases.Event.Register;
using System.Reflection;

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
            services.AddScoped<IGetAllEventUseCase, GetAllEventUseCase>();
            services.AddScoped<IGetEventByIdUseCase, GetEventByIdUseCase>();


            return services;
        }
    }
}
