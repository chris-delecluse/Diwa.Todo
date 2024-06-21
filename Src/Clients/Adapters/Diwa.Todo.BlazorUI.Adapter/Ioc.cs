using Diwa.Todo.BlazorUI.Adapter.ViewModels;
using Diwa.Todo.Client.Application;
using Diwa.Todo.HttpClient.Adapter;

namespace Diwa.Todo.BlazorUI.Adapter;

internal static class Ioc
{
    internal static IServiceCollection AddCustomServices(this IServiceCollection service)
    {
        service
            .AddDiwaTodoHttpClientAdapter()
            .AddDiwaTodoClientApplication();
        
        return service;
    }
    
    internal static IServiceCollection AddViewModels(this IServiceCollection service)
    {
        service.AddTransient<HomeViewModel>();
        
        return service;
    }
}