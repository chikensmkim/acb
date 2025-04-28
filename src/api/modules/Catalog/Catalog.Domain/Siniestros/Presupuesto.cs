using FSH.Framework.Core.Domain;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Presupuesto : AuditableEntity
{
    public Guid TenantId { get; set; }
    public Guid SiniestroId { get; private set; }
    public List<Repuesto> Repuestos { get; private set; } = new();
    public bool Aprobado { get; private set; }
    public string? Observacion { get; private set; }

    public Presupuesto(Guid siniestroId)
    {
        SiniestroId = siniestroId;
    }

    public Presupuesto Update(List<Repuesto> repuestos, bool aprobado, string? observacion)
    {
        Repuestos = repuestos;
        Aprobado = aprobado;
        Observacion = observacion;

        return this;
    }

    public void Aprobar() => Aprobado = true;
    public void Rechazar(string observacion) => Observacion = observacion;
}

