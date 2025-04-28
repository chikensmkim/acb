using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.Create.v1;
public sealed record CreateSiniestroCommand(
    [property: DefaultValue("ABC123")] string Patente,
    [property: DefaultValue("2025-04-26")] DateTime FechaOcurrencia,
    [property: DefaultValue("2025-04-27")] DateTime FechaDenuncia,
    [property: DefaultValue("Zona Norte")] string Zona,
    [property: DefaultValue(500000)] decimal CostoEstimado
) : IRequest<CreateSiniestroResponse>;
