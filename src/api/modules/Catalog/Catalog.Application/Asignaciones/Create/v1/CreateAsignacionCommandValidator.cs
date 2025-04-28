using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Asignaciones.Create.v1;
public class CreateAsignacionCommandValidator : AbstractValidator<CreateAsignacionCommand>
{
    public CreateAsignacionCommandValidator()
    {
        RuleFor(x => x.SiniestroId)
            .NotEmpty().WithMessage("Debe indicar el ID del siniestro.");

        RuleFor(x => x.TallerId)
            .NotEmpty().WithMessage("Debe indicar el ID del taller.");

        RuleFor(x => x.FechaAsignacion)
            .NotEmpty().WithMessage("Debe indicar la fecha de asignación.");
    }
}
