using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FSH.Starter.WebApi.Catalog.Domain.Enums;

namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.Update.v1;
public class UpdateSiniestroCommandValidator : AbstractValidator<UpdateSiniestroCommand>
{
    public UpdateSiniestroCommandValidator()
    {
        RuleFor(x => x.Patente)
            .NotEmpty()
            .MaximumLength(20)
            .Matches("^[A-Z]{2}[0-9]{4}$|^[A-Z]{4}[0-9]{2}$")
            .WithMessage("Formato de patente inválido (ej: AB1234 o ABCD12).");

        RuleFor(x => x.FechaOcurrencia)
            .NotEmpty();

        RuleFor(x => x.FechaDenuncia)
            .NotEmpty()
            .GreaterThanOrEqualTo(x => x.FechaOcurrencia);

        RuleFor(x => x.Zona)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.CostoEstimado)
            .GreaterThan(0);

        RuleFor(x => x.Estado)
            .Must(e => SiniestroEstado.ListaEstados.Contains(e))
            .WithMessage("Estado inválido.");
    }
}
