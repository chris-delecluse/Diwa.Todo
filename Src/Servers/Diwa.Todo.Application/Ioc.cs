using System.Reflection;
using Diwa.Todo.Application.Pipelines;
using Diwa.Todo.Port.Driving;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Diwa.Todo.Application;

public static class Ioc
{
    public static IServiceCollection AddDiwaTodoApplication(this IServiceCollection service)
    {
        service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        service.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        service.AddScoped<IProvideItem, Engine>();
        
        return service;
    }
}