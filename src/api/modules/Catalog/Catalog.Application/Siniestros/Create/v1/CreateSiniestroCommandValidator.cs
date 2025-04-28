using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.Create.v1;
public class CreateSiniestroCommandValidator : AbstractValidator<CreateSiniestroCommand>
{
    public CreateSiniestroCommandValidator()
    {
        RuleFor(x => x.Patente)
            .NotEmpty().WithMessage("La patente es obligatoria.")
            .MaximumLength(20)
            .Matches("^[A-Z]{2}[0-9]{4}$|^[A-Z]{4}[0-9]{2}$")
            .WithMessage("La patente debe tener un formato válido (ejemplo: AB1234 o ABCD12).");

        RuleFor(x => x.FechaOcurrencia)
            .NotEmpty().WithMessage("La fecha de ocurrencia es obligatoria.");

        RuleFor(x => x.FechaDenuncia)
            .NotEmpty().WithMessage("La fecha de denuncia es obligatoria.")
            .GreaterThanOrEqualTo(x => x.FechaOcurrencia)
            .WithMessage("La fecha de denuncia no puede ser anterior a la fecha de ocurrencia.");

        RuleFor(x => x.Zona)
            .NotEmpty().WithMessage("La zona es obligatoria.")
            .MaximumLength(100);

        RuleFor(x => x.CostoEstimado)
            .GreaterThan(0).WithMessage("El costo estimado debe ser mayor a cero.");
    }
}
