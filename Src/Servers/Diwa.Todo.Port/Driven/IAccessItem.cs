using Diwa.Todo.Common.DataModels;

namespace Diwa.Todo.Port.Driven;

public interface IAccessItem
{
    Task<IEnumerable<Item>> Get();
    
    Task<Item?> Get(Guid id);

    Task Post(Item item);

    void Put(Item item);
    
    void Delete(Item item);
}