using System.Collections.ObjectModel;
using Diwa.Todo.BlazorUI.Adapter.ViewModels._base;
using Diwa.Todo.Client.Application.Queries;
using Diwa.Todo.Common.DataModels;
using MediatR;

namespace Diwa.Todo.BlazorUI.Adapter.ViewModels;

public class HomeViewModel(ISender sender) : ViewModelBase
{
    public readonly ObservableCollection<Item> Items = new();
    
    public async Task LoadTodoItems()
    {
        if (Items.Any())
            Items.Clear();
        
        var result = await sender.Send(new GetAllTodoItemQuery());

        if (result is { IsSuccess: true, Data: not null })
            foreach (var item in result.Data.Items)
                Items.Add(item);
    }
}