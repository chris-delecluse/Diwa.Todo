using Diwa.Todo.Client.Port.Driving;
using Diwa.Todo.Common.DataModels;
using Diwa.Todo.Common.OperationResult;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Diwa.Todo.Client.Application.Queries.Handlers;

internal sealed class GetTodoItemByIdQueryHandler(
    IProvideTodoItem todoItemProvider,
    ILogger<GetTodoItemByIdQueryHandler> logger)
    : IRequestHandler<GetTodoItemByIdQuery, Result<Item>>
{
    public async Task<Result<Item>> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var item = await todoItemProvider.RetrieveItem(request.Id);

            return item is not null
                ? Result<Item>.Success(new SuccessData<Item>(item))
                : Result<Item>.Failure(new Error<Item>("Not found", $"The item with id {request.Id} was not found"));
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while fetching item data");
            
            return Result<Item>.Failure(new Error<Item>("http error", "An error occured while retrieve item."));
        }
    }
}