using Carter;
using Diwa.Todo.Application.Queries;
using MediatR;

namespace Diwa.Todo.Api.Adapter.Endpoints;

public class ItemsModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app
            .MapGroup("api/items")
            .AllowAnonymous();
        
        group.MapGet("", async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllItemQuery());

            return Results.Ok(result?.Data?.Items);
        });
    }
}