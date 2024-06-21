namespace Diwa.Todo.Client.Protocol;

public record UpdateItemRequestDto(string Text, bool IsDone);