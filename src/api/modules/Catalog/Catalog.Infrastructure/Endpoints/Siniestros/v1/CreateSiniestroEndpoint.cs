
using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Siniestros.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class CreateSiniestroEndpoint
{
    internal static RouteHandlerBuilder MapSiniestroCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async(CreateSiniestroCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateSiniestroEndpoint))
            .WithSummary("creates Siniestro")
            .WithDescription("creates a product")
            .Produces<CreateSiniestroResponse>()
            .RequirePermission("Permissions.Siniestros.Create")
            .MapToApiVersion(1);
    }
}
