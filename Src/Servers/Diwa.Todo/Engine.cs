using Diwa.Todo.Common.DataModels;
using Diwa.Todo.Port.Driven;
using Diwa.Todo.Port.Driving;

namespace Diwa.Todo;

public class Engine(IAccessItem accessItem) : IProvideItem
{
    public async Task<IEnumerable<Item>> RetrieveItems() => await accessItem.Get();

    public async Task<Item?> RetrieveItem(Guid id) => await accessItem.Get(id);

    public async Task InsertItem(Item item) => await accessItem.Post(item);

    public void UpdateItem(Item item) => accessItem.Put(item);

    public void DeleteItem(Item item) => accessItem.Delete(item);
}