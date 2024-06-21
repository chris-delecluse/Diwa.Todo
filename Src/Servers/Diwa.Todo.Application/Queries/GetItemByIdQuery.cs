using Diwa.Todo.Common.DataModels;
using Diwa.Todo.Common.OperationResult;
using MediatR;

namespace Diwa.Todo.Application.Queries;

public record GetItemByIdQuery(Guid Id) : IRequest<Result<Item>>;