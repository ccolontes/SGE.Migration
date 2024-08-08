using System.Diagnostics;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SGE.Domain.ProcessAggregate.ValueObjects;

using Process = SGE.Domain.ProcessAggregate.Process;

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
            ppb.ToTable("ProcessProcedures");

            ppb.WithOwner().HasForeignKey("ProcessId");

            ppb.HasKey("Id", "ProcessId");

            ppb.Property(p => p.Value)
                .HasColumnName("ProcedureId")
                .ValueGeneratedNever();

            ppb.HasData(
                new
            {
                Id = 1, ProcessId = ProcessId.Create(Guid.Parse("8f335e81-a531-4276-9ec9-e31497b437e7")), Value = Guid.Parse("7094ed31-49d9-4aed-8faa-d456d33d370f"),
            },
                new
            {
                Id = 2, ProcessId = ProcessId.Create(Guid.Parse("8f335e81-a531-4276-9ec9-e31497b437e7")), Value = Guid.Parse("118e29e1-2a44-45b8-90f5-6c05bde4a203"),
            });
        });

        builder.Metadata.FindNavigation(nameof(Process.ProceduresIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        ApplySeeders(builder);
    }

    private void ApplySeeders(EntityTypeBuilder<Process> builder)
    {
        builder.HasData(
            Process.Create(Guid.Parse("8f335e81-a531-4276-9ec9-e31497b437e7"), "Televisión"));
    }
}