using Diwa.Todo.Application.Abstractions;
using Diwa.Todo.Common.OperationResult;
using MediatR;

namespace Diwa.Todo.Application.Commands;

public record UpdateItemCommand(Guid Id, string Text, bool IsDone) : IRequest<Result<Unit>>, ICommandBase;