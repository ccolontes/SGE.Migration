using System.Drawing;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SGE.Domain.TermAggregate;
using SGE.Domain.TermAggregate.ValueObjects;

namespace SGE.Infrastructure.Terms.Persistence.Seeders;

public static class PeopleCondictionsSeeder
{
    public static void Apply(EntityTypeBuilder<Term> builder)
    {
        var parent = Term.Create("PERSONA_CONDICION", "Condición de persona", default, default, default);
        builder.HasData(
            parent,
            Term.Create("PERSONA_CONDICION_NACIONAL", "Nacional", default, default, parent.Id as TermId),
            Term.Create("PERSONA_CONDICION_INTERNACIONAL", "Extranjero", default, default, parent.Id as TermId));
    }
}

