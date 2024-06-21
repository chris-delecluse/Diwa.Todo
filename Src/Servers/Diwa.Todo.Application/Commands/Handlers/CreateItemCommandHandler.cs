using Diwa.Todo.Common.DataModels;
using Diwa.Todo.Common.OperationResult;
using Diwa.Todo.Port.Driven;
using Diwa.Todo.Port.Driving;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Diwa.Todo.Application.Commands.Handlers;

internal sealed class CreateItemCommandHandler(
    IProvideItem itemProvider,
    IUnitOfWork unitOfWork,
    ILogger<CreateItemCommandHandler> logger)
    : IRequestHandler<CreateItemCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await itemProvider.InsertItem(new Item(null, request.Text, false, DateTime.UtcNow));
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(SuccessData<Unit>.None);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while inserting data");
            
            return Result<Unit>.Failure(new Error<Unit>("Insertion error", "An error occurred while inserting data"));
        }
    }
}