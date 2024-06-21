using Diwa.Todo.Common.OperationResult;
using MediatR;

namespace Diwa.Todo.Client.Application.Commands;

public record UpdateTodoItemCommand(Guid Id, string Text, bool IsDone) : IRequest<Result<Unit>>;