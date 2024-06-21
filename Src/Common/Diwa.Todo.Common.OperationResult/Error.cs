namespace Diwa.Todo.Common.OperationResult;

public sealed record Error<TResult>(string Code, string? Description = default)
{
    public static readonly Error<TResult> None = new(string.Empty);

    public static implicit operator Result<TResult>(Error<TResult> error) => Result<TResult>.Failure(error);
}
