using System.Reflection;
using Diwa.Todo.Client.Port.Driving;
using Microsoft.Extensions.DependencyInjection;

namespace Diwa.Todo.Client.Application;

public static class Ioc
{
    public static IServiceCollection AddDiwaTodoClientApplication(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        
        service.AddScoped<IProvideTodoItem, Engine>();
        
        return service;
    }
}