namespace Diwa.Todo.Common.OperationResult;

public sealed record SuccessData<TResult>(TResult Items)
{
    public static readonly SuccessData<TResult>? None;

    public static implicit operator Result<TResult>(SuccessData<TResult>? result) => Result<TResult>.Success(result);
}