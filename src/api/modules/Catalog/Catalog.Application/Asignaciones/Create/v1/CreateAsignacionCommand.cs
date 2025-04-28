using System.ComponentModel;
    using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Asignaciones.Create.v1;
public sealed record CreateAsignacionCommand(
    [property: DefaultValue("guid-del-siniestro")] Guid SiniestroId,
    [property: DefaultValue("guid-del-taller")] Guid TallerId,
    [property: DefaultValue("2025-04-27")] DateTime FechaAsignacion
) : IRequest<CreateAsignacionResponse>;
