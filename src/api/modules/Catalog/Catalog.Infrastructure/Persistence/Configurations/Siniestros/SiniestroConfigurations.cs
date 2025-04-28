
using Finbuckle.MultiTenant;
using FSH.Starter.WebApi.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Persistence.Configurations;
internal sealed class SiniestroConfigurations : IEntityTypeConfiguration<Siniestro>
{

    public void Configure(EntityTypeBuilder<Siniestro> builder)
    {
        builder.IsMultiTenant(); // <-- HABILITA multitenancy automático
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Patente).HasMaxLength(20).IsRequired();
        builder.Property(x => x.Zona).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Estado).HasMaxLength(50).IsRequired();
        builder.Property(x => x.FechaOcurrencia).IsRequired();
        builder.Property(x => x.FechaDenuncia).IsRequired();
        builder.Property(x => x.CostoEstimado).IsRequired();
    }
}

