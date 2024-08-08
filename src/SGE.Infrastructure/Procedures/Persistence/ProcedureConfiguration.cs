using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SGE.Domain.ProcedureAggregate;
using SGE.Domain.ProcedureAggregate.ValueObjects;

namespace SGE.Infrastructure.Procedures.Persistence;

public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
{
    public void Configure(EntityTypeBuilder<Procedure> builder)
    {
        builder.ToTable("Procedures");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => ProcedureId.Create(value));

        builder.Property(x => x.Name).IsRequired();
        ApplySeeders(builder);
    }

    private void ApplySeeders(EntityTypeBuilder<Procedure> builder)
    {
        builder.HasData(
            Procedure.Create(Guid.Parse("7094ed31-49d9-4aed-8faa-d456d33d370f"), "Modificaciones de parametros técnicos"),
            Procedure.Create(Guid.Parse("118e29e1-2a44-45b8-90f5-6c05bde4a203"), "Modificaciones de parametros técnicos"));
    }
}