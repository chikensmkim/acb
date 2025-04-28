using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.Delete.v1;
public sealed class DeleteSiniestroHandler(
    ILogger<DeleteSiniestroHandler> logger,
    [FromKeyedServices("catalog:siniestros")] IRepository<Siniestro> repository)
    : IRequestHandler<DeleteSiniestroCommand>
{
    public async Task Handle(DeleteSiniestroCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var siniestro = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = siniestro ?? throw new SiniestroNotFoundException(request.Id);
        
        await repository.DeleteAsync(siniestro, cancellationToken);

        logger.LogInformation("Siniestro whit id : {SiniestroId} delected", siniestro.Id);
    }
}
