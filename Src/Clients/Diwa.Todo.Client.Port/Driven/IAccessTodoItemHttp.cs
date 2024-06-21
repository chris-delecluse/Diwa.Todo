using Diwa.Todo.Client.Protocol;
using Diwa.Todo.Common.DataModels;

namespace Diwa.Todo.Client.Port.Driven;

public interface IAccessTodoItemHttp
{
    Task<IEnumerable<Item>> Get();

    Task<Item?> Get(Guid id);

    Task Post(CreateItemRequestDto dto);
    
    Task Put(Guid id, UpdateItemRequestDto dto);
    
    Task Delete(Guid id);
}