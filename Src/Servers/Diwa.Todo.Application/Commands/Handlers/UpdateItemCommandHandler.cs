using Diwa.Todo.Common.DataModels;
using Diwa.Todo.Common.OperationResult;
using Diwa.Todo.Port.Driven;
using Diwa.Todo.Port.Driving;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Diwa.Todo.Application.Commands.Handlers;

internal sealed class UpdateItemCommandHandler(
    IProvideItem itemProvider,
    IUnitOfWork unitOfWork,
    ILogger<UpdateItemCommandHandler> logger) 
    : IRequestHandler<UpdateItemCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var outDatedItem = await itemProvider.RetrieveItem(request.Id);

        if (outDatedItem is null)
            return Result<Unit>.Failure(new Error<Unit>("Not found", "No item to update"));
        
        var updatedText = outDatedItem?.Text == request.Text ? outDatedItem.Text : request.Text;
        
        try
        { 
            itemProvider.UpdateItem(
                new Item(outDatedItem!.Id,
                    updatedText,
                    request.IsDone,
                    outDatedItem.CreatedAtUtc)
            );

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(SuccessData<Unit>.None);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while updating item with ID {ItemId}", request.Id);
            
            return Result<Unit>.Failure(new Error<Unit>("Update error", "An error occurred while updating data"));
        }
    }
}