using Diwa.Todo.Common.OperationResult;
using MediatR;

namespace Diwa.Todo.Client.Application.Commands;

public record CreateTodoItemCommand(string Text): IRequest<Result<Unit>>;