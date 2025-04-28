using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.Update.v1;
public sealed class UpdateSiniestroHandler(
    ILogger<UpdateSiniestroHandler> logger,
    [FromKeyedServices("catalog:siniestros")] IRepository<Siniestro> repository)
    : IRequestHandler<UpdateSiniestroCommand, Guid>
{
    public async Task<Guid> Handle(UpdateSiniestroCommand request, CancellationToken cancellationToken)
    {
        var siniestro = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (siniestro is null)
            throw new SiniestroNotFoundException(request.Id);

        siniestro.Update(
            request.Patente,
            request.FechaOcurrencia,
            request.FechaDenuncia,
            request.Estado,
            request.Zona,
            request.CostoEstimado
        );

        await repository.UpdateAsync(siniestro, cancellationToken);
        logger.LogInformation("Siniestro actualizado {SiniestroId}", siniestro.Id);

        return siniestro.Id;
    }
}
