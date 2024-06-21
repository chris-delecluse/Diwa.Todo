using Diwa.Todo.Client.Port.Driving;
using Diwa.Todo.Common.OperationResult;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Diwa.Todo.Client.Application.Commands.Handlers;

internal sealed class DeleteTodoItemCommandHandler(
    IProvideTodoItem todoItemProvider,
    ILogger<DeleteTodoItemCommandHandler> logger) 
    : IRequestHandler<DeleteTodoItemCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await todoItemProvider.DeleteItem(request.Id);

            return Result<Unit>.Success(SuccessData<Unit>.None);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while deleting items data");
            
            return Result<Unit>.Failure(new Error<Unit>("Http error", "An error occurred while deleting item"));
        }
    }
}