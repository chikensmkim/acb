using FSH.Framework.Core.Domain;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class OrdenReparacion : AuditableEntity, IMustHaveTenant
{
    public Guid TenantId { get; set; }
    public Guid SiniestroId { get; private set; }
    public DateTime FechaOrden { get; private set; }
    public decimal CostoTotal { get; private set; }
    public string Estado { get; private set; } = "Pendiente";


    public OrdenReparacion(Guid siniestroId, DateTime fechaOrden, decimal costoTotal, string estado, string taller, string patente, string? observaciones)
    {
        SiniestroId = siniestroId;
        FechaOrden = fechaOrden;
        CostoTotal = costoTotal;
        Estado = estado;
        Taller = taller;
        Patente = patente;
        Observaciones = observaciones;
    }
    public OrdenRepacion Update(string? estado = null, decimal? nuevoCosto = null)
    {
        if (!string.IsNullOrWhiteSpace(estado)) Estado = estado;
        if (nuevoCosto.HasValue) CostoTotal = nuevoCosto.Value;
        return this;
    }

