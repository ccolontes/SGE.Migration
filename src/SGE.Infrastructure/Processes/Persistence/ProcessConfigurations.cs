using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SGE.Domain.ProcessAggregate;
using SGE.Domain.ProcessAggregate.Entities;

namespace SGE.Infrastructure.Processes.Persistence;

public class ProcessConfigurations : IEntityTypeConfiguration<Process>
{
    public void Configure(EntityTypeBuilder<Process> builder)
    {
        builder.ToTable("Processes");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name).IsRequired();

        // builder.HasQueryFilter(x => !x.IsDeleted);
        builder.HasMany(x => x.Procedures).WithMany(x => x.Processes)
            .UsingEntity<ProcessProcedure>(
                "ProcessProcedure",
                l => l.HasOne(x => x.Procedure).WithMany().HasForeignKey(x => x.ProcedureId),
                r => r.HasOne(x => x.Process).WithMany().HasForeignKey(x => x.ProcessId),
                j => j.HasData(
                        new { ProcedureId = "d9a6b405-d552-4792-8ec5-588647ee9b67", ProcessId = "87bd871f-ab3c-46da-81c8-3f1e8dd27dfe" },
                        new { ProcedureId = "b106bb0d-d2ad-4b56-b644-8fa514c8d3b7", ProcessId = "87bd871f-ab3c-46da-81c8-3f1e8dd27dfe" }));

        ApplySeeders(builder);
    }

    private void ApplySeeders(EntityTypeBuilder<Process> builder)
    {
        builder.HasData(Process.Create("87bd871f-ab3c-46da-81c8-3f1e8dd27dfe", "Televisión"));
    }
}