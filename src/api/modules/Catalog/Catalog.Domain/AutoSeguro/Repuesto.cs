using FSH.Framework.Core.Domain;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Repuesto : AuditableEntity, IMustHaveTenant
{
    public Guid TenantId { get; set; }
    public string Descripcion { get; private set; } = default!;
    public decimal Costo { get; private set; }


    public Repuesto(string descripcion, decimal costo)
    {
        Descripcion = descripcion;
        Costo = costo;
    }
}
