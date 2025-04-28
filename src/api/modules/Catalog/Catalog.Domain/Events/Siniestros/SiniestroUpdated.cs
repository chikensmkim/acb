using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record SiniestroUpdated : DomainEvent
{
    public Siniestro? Siniestro { get; set; }
}
