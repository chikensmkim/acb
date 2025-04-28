using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.Get.v1;
public sealed record GetSiniestroHandler(
    [FromKeyedServices("catalog:siniestros")] IReadRepository<Siniestro> repository,
    ICacheService cache)
    : IRequestHandler<GetSiniestroRequest, SiniestroResponse>
{
    public async Task<SiniestroResponse> Handle(GetSiniestroRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"siniestro:{request.Id}",
            async () =>
            {
                var siniestroItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (siniestroItem == null) throw new SiniestroNotFoundException(request.Id);
                return new SiniestroResponse(
                    siniestroItem.Id, 
                    siniestroItem.Patente, 
                    siniestroItem.FechaOcurrencia, 
                    siniestroItem.FechaDenuncia, 
                    siniestroItem.Estado, 
                    siniestroItem.Zona, 
                    siniestroItem.CostoEstimado);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
