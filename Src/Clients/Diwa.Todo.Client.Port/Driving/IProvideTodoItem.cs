using Diwa.Todo.Client.Protocol;
using Diwa.Todo.Common.DataModels;

namespace Diwa.Todo.Client.Port.Driving;

public interface IProvideTodoItem
{
    Task<IEnumerable<Item>> RetrieveItems();

    Task<Item?> RetrieveItem(Guid id);

    Task InsertItem(CreateItemRequestDto dto);

    Task UpdateItem(Guid id, UpdateItemRequestDto dto);

    Task DeleteItem(Guid id);
}