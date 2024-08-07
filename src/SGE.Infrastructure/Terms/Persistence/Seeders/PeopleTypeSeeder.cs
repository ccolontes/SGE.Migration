using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SGE.Domain.TermAggregate;
using SGE.Domain.TermAggregate.ValueObjects;

namespace SGE.Infrastructure.Terms.Persistence.Seeders;

public static class PeopleTypeSeeder
{
    public static void Apply(EntityTypeBuilder<Term> builder)
    {
        var parent = Term.Create("PERSONA_TIPO", "Tipo de persona", default, default, default);
        builder.HasData(
            parent,
            Term.Create("PERSONA_TIPO_NATURAL", "Natural", default, default, parent.Id as TermId),
            Term.Create("PERSONA_TIPO_JURIDICA", "Juridica", default, default, parent.Id as TermId));
    }
}