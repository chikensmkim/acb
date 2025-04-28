using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Enums;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Siniestro : AuditableEntity, IAggregateRoot
{
    public string Patente { get; private set; } = default!;
    public DateTime FechaOcurrencia { get; private set; }
    public DateTime FechaDenuncia { get; private set; }
    public string Estado { get; private set; } = SiniestroEstado.Pendiente;
    public string Zona { get; private set; }
    public decimal CostoEstimado { get; private set; }

    public static Siniestro Create(string patente, DateTime fechaOcurrencia, DateTime fechaDenuncia, string zona, decimal costoEstimado)
    {
        var siniestro = new Siniestro();
        siniestro.Patente = patente;
        siniestro.FechaOcurrencia = fechaOcurrencia;
        siniestro.FechaDenuncia = fechaDenuncia;
        siniestro.Estado = SiniestroEstado.Pendiente;
        siniestro.Zona = zona;
        siniestro.CostoEstimado = costoEstimado;

        siniestro.QueueDomainEvent(new SiniestroCreated() { Siniestro = siniestro });
        return siniestro;
    }

    public Siniestro Update(string patente, DateTime fechaOcurrencia, DateTime fechaDenuncia, string estado, string zona, decimal costoEstimado)
    {
        if (patente is not null && Patente?.Equals(patente, StringComparison.OrdinalIgnoreCase) is not true) Patente = patente;
        if (fechaOcurrencia != default && FechaOcurrencia != fechaOcurrencia) FechaOcurrencia = fechaOcurrencia;
        if (fechaDenuncia != default && FechaDenuncia != fechaDenuncia) FechaDenuncia = fechaDenuncia;

        if (!string.IsNullOrWhiteSpace(estado) && SiniestroEstado.ListaEstados.Contains(estado))
        {
            Estado = estado;
        }
        else
        {
            throw new ArgumentException($"Estado inválido: {estado}");
        }

        if (zona is not null && Zona?.Equals(zona, StringComparison.OrdinalIgnoreCase) is not true) Zona = zona;
        if (costoEstimado != default && CostoEstimado != costoEstimado) CostoEstimado = costoEstimado;


        this.QueueDomainEvent(new SiniestroUpdated() { Siniestro = this });
        return this;
    }

    public static Siniestro Update(Guid id, string patente, DateTime fechaOcurrencia, DateTime fechaDenuncia, string estado, string zona, decimal costoEstimado)
    {
        var siniestro = new Siniestro
        {
            Id = id,
            Patente = patente,
            FechaOcurrencia = fechaOcurrencia,
            FechaDenuncia = fechaDenuncia,
            Estado = estado,
            Zona = zona,
            CostoEstimado = costoEstimado
        };

        siniestro.QueueDomainEvent(new SiniestroUpdated() { Siniestro = siniestro });
        return siniestro;
    }


}

