
using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.Update.v1;
public sealed record UpdateSiniestroCommand(
    Guid Id,
    [property: DefaultValue("ABC123")] string Patente,
    [property: DefaultValue("2025-04-26")] DateTime FechaOcurrencia,
    [property: DefaultValue("2025-04-27")] DateTime FechaDenuncia,
    [property: DefaultValue("Presupuestado")] string Estado,
    [property: DefaultValue("Zona Norte")] string Zona,
    [property: DefaultValue(500000)] decimal CostoEstimado
) : IRequest<Guid>;
