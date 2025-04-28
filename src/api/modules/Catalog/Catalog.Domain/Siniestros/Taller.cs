using FSH.Framework.Core.Domain;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Taller : AuditableEntity
{
    public Guid TenantId { get; set; }
    public string Nombre { get; private set; } = default!;
    public string Ubicacion { get; private set; } = default!;
    public string Telefono { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string? Observaciones { get; private set; }

    public Taller(string nombre, string ubicacion)
    {
        Nombre = nombre;
        Ubicacion = ubicacion;

    }
}
