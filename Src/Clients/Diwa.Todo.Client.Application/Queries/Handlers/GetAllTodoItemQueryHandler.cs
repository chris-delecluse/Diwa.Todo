using Diwa.Todo.Client.Port.Driving;
using Diwa.Todo.Common.DataModels;
using Diwa.Todo.Common.OperationResult;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Diwa.Todo.Client.Application.Queries.Handlers;

internal sealed class GetAllTodoItemQueryHandler(
    IProvideTodoItem todoItemProvider, 
    ILogger<GetAllTodoItemQueryHandler> logger)
    : IRequestHandler<GetAllTodoItemQuery, Result<IEnumerable<Item>>>
{
    public async Task<Result<IEnumerable<Item>>> Handle(GetAllTodoItemQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var items = await todoItemProvider.RetrieveItems();
            
            return Result<IEnumerable<Item>>.Success(new SuccessData<IEnumerable<Item>>(items));
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while fetching items data");
            
            return Result<IEnumerable<Item>>.Failure(new Error<IEnumerable<Item>>("http error", "An error occured while retrieve items."));
        }
    }
}