using Diwa.Todo.Common.DataModels;

namespace Diwa.Todo.Port.Driving;

public interface IProvideItem
{
    Task<IEnumerable<Item>> RetrieveItems();
    
    Task<Item?> RetrieveItem(Guid id);

    Task InsertItem(Item item);

    void UpdateItem(Item item);

    void DeleteItem(Item item);
}