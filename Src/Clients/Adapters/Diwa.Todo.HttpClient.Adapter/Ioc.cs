using Diwa.Todo.Client.Port.Driven;
using Diwa.Todo.HttpClient.Adapter.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Diwa.Todo.HttpClient.Adapter;

public static class Ioc
{
    public static IServiceCollection AddDiwaTodoHttpClientAdapter(this IServiceCollection service)
    {
        service.AddHttpClient("todo", opt => opt.BaseAddress = new(Constants.TodoApiBaseAddress));

        service.AddScoped<IAccessTodoItemHttp, TodoItemService>();
        
        return service;
    }
}