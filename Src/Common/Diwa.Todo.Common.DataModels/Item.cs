namespace Diwa.Todo.Common.DataModels;

public record Item(
    Guid? Id,
    string Text,
    bool IsDone,
    DateTime CreatedAtUtc);