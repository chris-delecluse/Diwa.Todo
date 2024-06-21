using Diwa.Todo.Common.DataModels;
using Diwa.Todo.Common.OperationResult;
using Diwa.Todo.Port.Driving;
using MediatR;

namespace Diwa.Todo.Application.Queries.Handlers;

internal sealed class GetItemByIdQueryHandler(IProvideItem itemProvider) : IRequestHandler<GetItemByIdQuery, Result<Item>>
{
    public async Task<Result<Item>> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await itemProvider.RetrieveItem(request.Id);

        return item is not null
            ? Result<Item>.Success(new SuccessData<Item>(item))
            : Result<Item>.Failure(new Error<Item>("Not found", $"Item with id {request.Id} was not found"));
    }
}