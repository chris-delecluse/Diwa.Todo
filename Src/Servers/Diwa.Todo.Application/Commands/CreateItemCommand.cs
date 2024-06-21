using Diwa.Todo.Application.Abstractions;
using Diwa.Todo.Common.OperationResult;
using MediatR;

namespace Diwa.Todo.Application.Commands;

public record CreateItemCommand(string Text) : IRequest<Result<Unit>>, ICommandBase;