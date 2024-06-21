using Diwa.Todo.Application.Abstractions;
using Diwa.Todo.Common.OperationResult;
using MediatR;

namespace Diwa.Todo.Application.Commands;

public record DeleteItemCommand(Guid Id) : IRequest<Result<Unit>>, ICommandBase;