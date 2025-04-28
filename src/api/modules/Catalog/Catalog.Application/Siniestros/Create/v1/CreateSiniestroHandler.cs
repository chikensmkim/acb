using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.Create.v1;
public sealed class CreateSiniestroHandler(
    ILogger<CreateSiniestroHandler> logger,
    [FromKeyedServices("catalog:siniestros")] IRepository<Siniestro> repository)
    : IRequestHandler<CreateSiniestroCommand, CreateSiniestroResponse>
{
    public async Task<CreateSiniestroResponse> Handle(CreateSiniestroCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var siniestro = Siniestro.Create(
            request.Patente,
            request.FechaOcurrencia,
            request.FechaDenuncia,
            request.Zona,
            request.CostoEstimado
        );
       
        await repository.AddAsync(siniestro, cancellationToken);
        logger.LogInformation("Siniestro creado {SiniestroId}", siniestro.Id);
        return new CreateSiniestroResponse(siniestro.Id);
    }
}
