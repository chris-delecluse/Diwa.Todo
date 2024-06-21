using Diwa.Todo.Common.OperationResult;
using Diwa.Todo.Port.Driven;
using Diwa.Todo.Port.Driving;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Diwa.Todo.Application.Commands.Handlers;

public class DeleteItemCommandHandler(
    IProvideItem itemProvider,
    IUnitOfWork unitOfWork,
    ILogger<DeleteItemCommandHandler> logger)
    : IRequestHandler<DeleteItemCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var itemToDelete = await itemProvider.RetrieveItem(request.Id);

        if (itemToDelete is null)
            return Result<Unit>.Failure(new Error<Unit>("Not found", "No item to delete"));

        try
        {
            itemProvider.DeleteItem(itemToDelete);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(SuccessData<Unit>.None);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while deleting item with ID {ItemId}", request.Id);

            return Result<Unit>.Failure(new Error<Unit>("Delete error", "An error occurred while deleting data"));
        }
    }
}