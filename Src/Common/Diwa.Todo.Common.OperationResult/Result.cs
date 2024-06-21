namespace Diwa.Todo.Common.OperationResult;

public class Result<TResult>
{
    public bool IsSuccess { get; }
    public Error<TResult> Error { get; }
    public SuccessData<TResult>? Data { get; }

    private Result(bool isSuccess, Error<TResult> error)
    {
        if (isSuccess && error != Error<TResult>.None || !isSuccess && error == Error<TResult>.None)
            throw new ArgumentException("Invalid error", nameof(error));

        IsSuccess = isSuccess;
        Error = error;
        Data = SuccessData<TResult>.None;
    }

    private Result(bool isSuccess, SuccessData<TResult>? success)
    {
        IsSuccess = isSuccess;
        Data = success;
        Error = Error<TResult>.None;
    }

    public static Result<TResult> Failure(Error<TResult> error) => new(false, error);

    public static Result<TResult> Success(SuccessData<TResult>? result = default) => new(true, result);
}