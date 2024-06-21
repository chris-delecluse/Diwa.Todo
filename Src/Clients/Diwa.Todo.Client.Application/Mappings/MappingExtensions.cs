using Diwa.Todo.Client.Application.Commands;
using Diwa.Todo.Client.Protocol;

namespace Diwa.Todo.Client.Application.Mappings;

internal static class MappingExtensions
{
    internal static CreateItemRequestDto ToRequestDto(this CreateTodoItemCommand command)
        => new(command.Text);
    
    internal static UpdateItemRequestDto ToRequestDto(this UpdateTodoItemCommand command)
        => new(command.Text, command.IsDone);
}