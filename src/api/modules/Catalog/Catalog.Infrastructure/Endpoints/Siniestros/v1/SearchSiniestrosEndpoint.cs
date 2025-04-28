using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Siniestros.Get.v1;
using FSH.Starter.WebApi.Catalog.Application.Siniestros.Search.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class SearchSiniestrosEndpoint
{
    internal static RouteHandlerBuilder MapGetSiniestroListEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async (PaginationFilter filter, ISender mediator) =>
            {
                var result = await mediator.Send(new SearchSiniestrosCommand(filter));
                return Results.Ok(result);
            })
            .WithName(nameof(SearchSiniestrosEndpoint))
            .WithSummary("Busca siniestros paginados")
            .WithDescription("Busca siniestros usando filtros de paginación")
            .Produces<PagedList<SiniestroResponse>>()
            .RequirePermission("Permissions.Siniestros.View")
            .MapToApiVersion(1);
    }
}
