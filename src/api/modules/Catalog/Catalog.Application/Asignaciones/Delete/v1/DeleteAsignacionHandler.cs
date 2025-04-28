using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Asignaciones.Delete.v1;
public sealed record DeleteAsignacionCommand(Guid Id) : IRequest<Guid>;
