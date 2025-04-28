using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Siniestros.Delete.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class DeleteSiniestroEndpoint
{
    internal static RouteHandlerBuilder MapSiniestroDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
             {
                 await mediator.Send(new DeleteSiniestroCommand(id));
                 return Results.NoContent();
             })
            .WithName(nameof(DeleteSiniestroEndpoint))
            .WithSummary("deletes siniestro by id")
            .WithDescription("deletes siniestro by id")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Siniestros.Delete")
            .MapToApiVersion(1);
    }
}
