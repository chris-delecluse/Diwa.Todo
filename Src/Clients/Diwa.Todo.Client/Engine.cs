using Diwa.Todo.Client.Port.Driven;
using Diwa.Todo.Client.Port.Driving;
using Diwa.Todo.Client.Protocol;
using Diwa.Todo.Common.DataModels;

namespace Diwa.Todo.Client;

public class Engine(IAccessTodoItemHttp accessTodoItemHttp) : IProvideTodoItem
{
    public async Task<IEnumerable<Item>> RetrieveItems() => await accessTodoItemHttp.Get();

    public async Task<Item?> RetrieveItem(Guid id) => await accessTodoItemHttp.Get(id);
    
    public async Task InsertItem(CreateItemRequestDto dto)=> await accessTodoItemHttp.Post(dto);

    public async Task UpdateItem(Guid id, UpdateItemRequestDto dto) => await accessTodoItemHttp.Put(id, dto);

    public async Task DeleteItem(Guid id) => await accessTodoItemHttp.Delete(id);
}