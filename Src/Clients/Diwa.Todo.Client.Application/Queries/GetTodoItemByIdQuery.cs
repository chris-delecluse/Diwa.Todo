using Diwa.Todo.Common.DataModels;
using Diwa.Todo.Common.OperationResult;
using MediatR;

namespace Diwa.Todo.Client.Application.Queries;

public record GetTodoItemByIdQuery(Guid Id) : IRequest<Result<Item>>;