
using FSH.Starter.WebApi.Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Finbuckle.MultiTenant;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Persistence.Configurations.Asignaciones;
internal sealed class AsignacionConfiguration : IEntityTypeConfiguration<Asignacion>
{
    public void Configure(EntityTypeBuilder<Asignacion> builder)
    {
        builder.IsMultiTenant(); // Habilita el filtro automático de multitenancy en consultas.
        builder.HasKey(x => x.Id); // Clave primaria

        builder.Property(x => x.SiniestroId).IsRequired();
        builder.Property(x => x.TallerId).IsRequired();
        builder.Property(x => x.FechaAsignacion).IsRequired();
    }
}
