using System.Reflection;
using Diwa.Todo.Database.Adapter.Repositories;
using Diwa.Todo.Port.Driven;
using Diwa.Todo.Port.Driving;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Diwa.Todo.Database.Adapter;

public static class Ioc
{
    public static IServiceCollection AddDiwaTodoDatabaseAdapter(this IServiceCollection service)
    {
        service.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("todo"));
        service.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        service.AddScoped<IUnitOfWork>(sc => sc.GetRequiredService<AppDbContext>());
        service.AddScoped<IAccessItem, ItemRepository>();
        
        return service;
    }
}