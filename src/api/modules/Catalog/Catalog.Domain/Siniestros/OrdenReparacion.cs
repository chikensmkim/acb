using FSH.Framework.Core.Domain;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class OrdenReparacion : AuditableEntity 
{
    public Guid TenantId { get; set; }
    public Guid SiniestroId { get; private set; }
    public DateTime FechaOrden { get; private set; }
    public decimal CostoTotal { get; private set; }
    public string Estado { get; private set; } = "Pendiente";


    public OrdenReparacion(Guid siniestroId, DateTime fechaOrden, decimal costoTotal, string estado)
    {
        SiniestroId = siniestroId;
        FechaOrden = fechaOrden;
        CostoTotal = costoTotal;
        Estado = estado;
     
    }
  
}


