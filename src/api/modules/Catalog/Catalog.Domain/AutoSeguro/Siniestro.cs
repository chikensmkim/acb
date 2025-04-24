using FSH.Framework.Core.Domain;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Siniestro : AuditableEntity, IMustHaveTenant
{
    public Guid TenantId { get; set; }
    public string Patente { get; private set; } = default!;
    public DateTime FechaOcurrencia { get; private set; }
    public DateTime FechaDenuncia { get; private set; }
    public string Estado { get; private set; } = "Presupuestado";
    public string Zona { get; private set; }
    public decimal CostoEstimado { get; private set; }

    public Siniestro(string patente, DateTime fechaOcurrencia, DateTime fechaDenuncia, string zona, decimal costoEstimado)
    {
        Patente = patente;
        FechaOcurrencia = fechaOcurrencia;
        FechaDenuncia = fechaDenuncia;
        Zona = zona;
        CostoEstimado = costoEstimado;
    }

    public Siniestro Update(string patente, DateTime fechaOcurrencia, DateTime fechaDenuncia, string estado, string zona, decimal costoEstimado)
    {
        Patente = patente;
        FechaOcurrencia = fechaOcurrencia;
        FechaDenuncia = fechaDenuncia;
        Estado = estado;
        Zona = zona;
        CostoEstimado = costoEstimado;

        return this;
    }
}
}
