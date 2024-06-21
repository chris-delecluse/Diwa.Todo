using Carter;
using Diwa.Todo.Api.Adapter.DTO;
using Diwa.Todo.Api.Adapter.DTO.Mappings;
using Diwa.Todo.Application.Commands;
using Diwa.Todo.Application.Queries;
using MediatR;

namespace Diwa.Todo.Api.Adapter.Endpoints;

public class ItemModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app
            .MapGroup("api/item")
            .AllowAnonymous();
        
        group.MapGet("{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetItemByIdQuery(id));

            return result.IsSuccess
                ? Results.Ok(result?.Data?.Items)
                : Results.NotFound();
        });
        
        group.MapPost("", async (CreateItemCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            
            return result.IsSuccess
                ? Results.Created("", result?.Data?.Items)
                : Results.BadRequest();
        });
        
        group.MapPut("{id}", async (Guid id, UpdateItemRequestDto dto, ISender sender) =>
        {
            var result = await sender.Send(dto.ToCommand(id));
            
            return result.IsSuccess
                ? Results.NoContent()
                : Results.NotFound();
        });
        
        group.MapDelete("{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteItemCommand(id));
            
            return result.IsSuccess
                ? Results.NoContent()
                : Results.NotFound();
        });
    }
}