using Diwa.Todo.Application;
using Diwa.Todo.Database.Adapter;

namespace Diwa.Todo.Api.Adapter;

internal static class Ioc
{
    internal static IServiceCollection AddCustomServices(this IServiceCollection service)
    {
        service
            .AddDiwaTodoDatabaseAdapter()
            .AddDiwaTodoApplication();
        
        return service;
    }
}