using Diwa.Todo.Common.OperationResult;
using MediatR;

namespace Diwa.Todo.Client.Application.Commands;

public record DeleteTodoItemCommand(Guid Id) : IRequest<Result<Unit>>;