using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SGE.Domain.ProcessAggregate.Entities;

namespace SGE.Infrastructure.Processes.Persistence;

public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
{
    public void Configure(EntityTypeBuilder<Procedure> builder)
    {
        builder.ToTable("Procedures");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);
        builder.Property(x => x.Name).IsRequired();

        ApplySeeders(builder);
    }

    private void ApplySeeders(EntityTypeBuilder<Procedure> builder)
    {
        builder.HasData(
            Procedure.Create("d9a6b405-d552-4792-8ec5-588647ee9b67", "Otorgamiento de frecuenias"),
            Procedure.Create("b106bb0d-d2ad-4b56-b644-8fa514c8d3b7", "Modificaciones de parametros técnicos"));
    }
}