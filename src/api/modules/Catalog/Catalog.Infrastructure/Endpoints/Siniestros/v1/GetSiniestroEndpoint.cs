using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Siniestros.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class GetSiniestroEndpoint
{
    internal static RouteHandlerBuilder MapGetSiniestroEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var result = await mediator.Send(new GetSiniestroRequest(id));
                return Results.Ok(result);
            })
            .WithName(nameof(GetSiniestroEndpoint))
            .WithSummary("Obtiene un siniestro por ID")
            .WithDescription("Obtiene los detalles de un siniestro existente")
            .Produces<SiniestroResponse>()
            .RequirePermission("Permissions.Siniestros.View")
            .MapToApiVersion(1);
    }
}
