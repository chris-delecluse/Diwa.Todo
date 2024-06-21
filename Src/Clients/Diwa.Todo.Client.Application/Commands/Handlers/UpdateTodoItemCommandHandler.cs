using Diwa.Todo.Client.Application.Mappings;
using Diwa.Todo.Client.Port.Driving;
using Diwa.Todo.Common.OperationResult;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Diwa.Todo.Client.Application.Commands.Handlers;

internal sealed class UpdateTodoItemCommandHandler(
    IProvideTodoItem todoItemProvider,
    ILogger<UpdateTodoItemCommandHandler> logger) 
    : IRequestHandler<UpdateTodoItemCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await todoItemProvider.UpdateItem(request.Id, request.ToRequestDto());

            return Result<Unit>.Success(SuccessData<Unit>.None);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while updating items data");
            
            return Result<Unit>.Failure(new Error<Unit>("Http error", "An error occurred while updating item"));
        }
    }
}