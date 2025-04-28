
using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Siniestros.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class UpdateSiniestroEndpoint
{
    internal static RouteHandlerBuilder MapSiniestroUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateSiniestroCommand command, ISender mediator) =>
            {
                if (id != command.Id) return Results.BadRequest("El ID en la ruta y el ID en el body no coinciden.");

                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName(nameof(UpdateSiniestroEndpoint))
            .WithSummary("Actualiza un siniestro existente")
            .WithDescription("Actualiza la información de un siniestro")
            .Produces<Guid>()
            .RequirePermission("Permissions.Siniestros.Update")
            .MapToApiVersion(1);
    }
}
