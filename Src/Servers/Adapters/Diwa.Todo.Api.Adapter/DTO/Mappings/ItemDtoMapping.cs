using Diwa.Todo.Application.Commands;

namespace Diwa.Todo.Api.Adapter.DTO.Mappings;

internal static class ItemDtoMapping
{
    internal static UpdateItemCommand ToCommand(this UpdateItemRequestDto dto, Guid id)
        => new(id, dto.Text, dto.IsDone);
}