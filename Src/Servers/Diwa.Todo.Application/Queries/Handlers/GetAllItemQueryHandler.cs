using Diwa.Todo.Common.DataModels;
using Diwa.Todo.Common.OperationResult;
using Diwa.Todo.Port.Driving;
using MediatR;

namespace Diwa.Todo.Application.Queries.Handlers;

internal sealed class GetAllItemQueryHandler(IProvideItem itemProvider)
    : IRequestHandler<GetAllItemQuery, Result<IEnumerable<Item>>>
{
    public async Task<Result<IEnumerable<Item>>> Handle(GetAllItemQuery request, CancellationToken cancellationToken)
        => Result<IEnumerable<Item>>.Success(new SuccessData<IEnumerable<Item>>(await itemProvider.RetrieveItems()));
}