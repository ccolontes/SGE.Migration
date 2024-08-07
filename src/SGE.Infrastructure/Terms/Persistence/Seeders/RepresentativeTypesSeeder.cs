using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SGE.Domain.TermAggregate;
using SGE.Domain.TermAggregate.ValueObjects;

namespace SGE.Infrastructure.Terms.Persistence.Seeders;

public static class RepresentativeTypesSeeder
{
    public static void Apply(EntityTypeBuilder<Term> builder)
    {
        var parent = Term.Create("REPRESENTANTE_TIPO", "Tipo de representante", default, default, default);
        builder.HasData(
            parent,
            Term.Create("REPRESENTANTE_TIPO_LEGAL_ILIMITADO_EN_SUS_FACULTADES", "Representante legal ilimitado en sus facultades", "Aquel que de acuerdo con lo expresado en el certificado de existencia y representación legal de la empresa posee plenas facultades para solicitar permisos de espectro a nombre de la empresa que representa.", default, parent.Id as TermId),
            Term.Create("REPRESENTANTE_TIPO_LEGAL_LIMITADO_EN_SUS_FACULTADES", "Representante legal limitado en sus facultades",  "Aquel que de acuerdo con lo expresado en el certificado de existencia y representación legal de la empresa no posee plenas facultades para solicitar permisos de espectro a nombre de la empresa que representa, por lo cual, requiere de la presentación de un poder adicional que lo faculte para realizar solicitudes de este tipo.", default, parent.Id as TermId),
            Term.Create("REPRESENTANTE_TIPO_APODERADO", "Apoderado",  "Aquella persona designada mediante poder general o especial, conferido por el representante legal con facultades para ello, para solicitar permisos de espectro a nombre de la empresa que representa.", default, parent.Id as TermId));
    }
}