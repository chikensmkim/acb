using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Asignaciones.Create.v1;
public sealed class CreateAsignacionHandler(
    ILogger<CreateAsignacionHandler> logger,
    [FromKeyedServices("catalog:asignaciones")] IRepository<Asignacion> repository)
    : IRequestHandler<CreateAsignacionCommand, CreateAsignacionResponse>
{
    public async Task<CreateAsignacionResponse> Handle(CreateAsignacionCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var asignacion = Asignacion.Create(
            request.SiniestroId,
            request.TallerId,
            request.FechaAsignacion
        );


        await repository.AddAsync(asignacion, cancellationToken);
        logger.LogInformation("Asignación creada {AsignacionId}", asignacion.Id);
        return new CreateAsignacionResponse(asignacion.Id);
    }
}
