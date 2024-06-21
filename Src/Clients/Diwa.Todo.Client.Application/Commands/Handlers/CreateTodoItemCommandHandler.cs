using Diwa.Todo.Client.Application.Mappings;
using Diwa.Todo.Client.Port.Driving;
using Diwa.Todo.Client.Protocol;
using Diwa.Todo.Common.DataModels;
using Diwa.Todo.Common.OperationResult;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Diwa.Todo.Client.Application.Commands.Handlers;

internal sealed class CreateTodoItemCommandHandler(
    IProvideTodoItem todoItemProvider,
    ILogger<CreateTodoItemCommandHandler> logger) 
    : IRequestHandler<CreateTodoItemCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await todoItemProvider.InsertItem(request.ToRequestDto());

            return Result<Unit>.Success(SuccessData<Unit>.None);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while posting items data");
            
            return Result<Unit>.Failure(new Error<Unit>("Http error", "An error occurred while posting item"));
        }
    }
}