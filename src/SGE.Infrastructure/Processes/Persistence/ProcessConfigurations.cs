using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SGE.Domain.ProcedureAggregate.ValueObjects;
using SGE.Domain.ProcessAggregate;
using SGE.Domain.ProcessAggregate.Entities;
using SGE.Domain.ProcessAggregate.ValueObjects;

namespace SGE.Infrastructure.Processes.Persistence;

public class ProcessConfigurations : IEntityTypeConfiguration<Process>
{
    public void Configure(EntityTypeBuilder<Process> builder)
    {
        builder.ToTable("Processes");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => ProcessId.Create(value));

        builder.Property(x => x.Name).IsRequired();

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.OwnsMany(x => x.ProceduresIds, ppb =>
        {
            ppb.ToTable("ProcessProcedure");

            ppb.WithOwner().HasForeignKey("ProcessId");

            ppb.HasKey("Id", "ProcessId");

            ppb.Property(p => p.Value)
                .HasColumnName("ProcessProcedureId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Process.ProceduresIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        ApplySeeders(builder);
    }

    private void ApplySeeders(EntityTypeBuilder<Process> builder)
    {
        builder.HasData(Process.Create(Guid.Parse("8f335e81-a531-4276-9ec9-e31497b437e7"), "Televisión"));
    }
}