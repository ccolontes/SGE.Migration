using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SGE.Domain.TermAggregate;
using SGE.Domain.TermAggregate.ValueObjects;
using SGE.Infrastructure.Terms.Persistence.Seeders;

namespace SGE.Infrastructure.Terms.Persistence;

public class TermConfiguration : IEntityTypeConfiguration<Term>
{
    public void Configure(EntityTypeBuilder<Term> builder)
    {
        builder.ToTable("Terms");

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value.ToString(), value => TermId.Create(value));

        builder.Property(x => x.Code).IsRequired();
        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.ParentId)
            .ValueGeneratedNever()
            .HasConversion(id => id!.Value.ToString(), value => TermId.Create(value))
            .IsRequired(false);

        builder.HasMany(x => x.Terms)
            .WithOne(x => x.Parent)
            .HasForeignKey(x => x.ParentId)
            .IsRequired(false);

        PeopleTypeSeeder.Apply(builder);
        ApplicationStatesSeeder.Apply(builder);
        PeopleCondictionsSeeder.Apply(builder);
        RepresentativeTypesSeeder.Apply(builder);
    }
}