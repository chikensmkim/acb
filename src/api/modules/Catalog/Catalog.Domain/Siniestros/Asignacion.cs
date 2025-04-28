using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Asignacion : AuditableEntity, IAggregateRoot
{
    public Guid SiniestroId { get; private set; }
    public Guid TallerId { get; private set; }
    public DateTime FechaAsignacion { get; private set; }

    // Constructor privado para EF Core
    private Asignacion() { }

    // Constructor privado controlado
    private Asignacion(Guid siniestroId, Guid tallerId, DateTime fechaAsignacion)
    {
        SiniestroId = siniestroId;
        TallerId = tallerId;
        FechaAsignacion = fechaAsignacion;

        QueueDomainEvent(new AsignacionCreated { Asignacion = this });
    }

    // Método estático de creación
    public static Asignacion Create(Guid siniestroId, Guid tallerId, DateTime fechaAsignacion)
    {
        return new Asignacion(siniestroId, tallerId, fechaAsignacion);
    }

    // Método para actualizar la asignación
    public Asignacion Update(Guid? nuevoTallerId = null, DateTime? nuevaFechaAsignacion = null)
    {
        bool updated = false;

        if (nuevoTallerId.HasValue && nuevoTallerId != TallerId)
        {
            TallerId = nuevoTallerId.Value;
            updated = true;
        }

        if (nuevaFechaAsignacion.HasValue && nuevaFechaAsignacion != FechaAsignacion)
        {
            FechaAsignacion = nuevaFechaAsignacion.Value;
            updated = true;
        }

        if (updated)
        {
            QueueDomainEvent(new AsignacionUpdated { Asignacion = this });
        }

        return this;
    }
}
