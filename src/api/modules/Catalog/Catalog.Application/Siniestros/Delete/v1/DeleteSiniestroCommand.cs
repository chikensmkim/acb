using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.Delete.v1;

public sealed record DeleteSiniestroCommand(Guid Id) : IRequest;
