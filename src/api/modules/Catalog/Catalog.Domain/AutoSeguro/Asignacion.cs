using FSH.Framework.Core.Domain;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Asignacion : AuditableEntity, IMustHaveTenant
{
    public Guid TenantId { get; set; }
    public Guid SiniestroId { get; private set; }
    public Guid TallerId { get; private set; }
    public DateTime FechaAsignacion { get; private set; }


    public Asignacion(Guid siniestroId, Guid tallerId, DateTime fechaAsignacion)
    {
        SiniestroId = siniestroId;
        TallerId = tallerId;
        FechaAsignacion = fechaAsignacion;
    }



}
