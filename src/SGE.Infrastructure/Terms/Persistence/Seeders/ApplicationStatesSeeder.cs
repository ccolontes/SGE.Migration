using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SGE.Domain.TermAggregate;
using SGE.Domain.TermAggregate.ValueObjects;

namespace SGE.Infrastructure.Terms.Persistence.Seeders;

public static class ApplicationStatesSeeder
{
    public static void Apply(EntityTypeBuilder<Term> builder)
    {
        var parent = Term.Create("SOLICITUD_ESTADO", "Estados de una solicitud", default, default, default);
        builder.HasData(
            parent,
            Term.Create("SOLICITUD_ESTADO_PENDIENTE_RADICACIÓN", "Pendiente Radicación", "Solicitud que no ha sido radicada", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_EN_REVISION", "En revision", "Solicitud radicada y en flujo de revisión", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_APROBADA", "Aprobada", "Solicitud aprobada", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_REQUERIDA", "Requerida", "Solicitud requerida", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_RECHAZADA", "Rechazada", "Solicitud rechaza", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_DESISTIDA", "Desistida", "Solicitud desistida por el operador", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_DESISTIDA_TACITAMENTE", "Desistida tacitamente", "Solicitud rechazada por no realizar la subsanación en el tiempo establecido", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_SUBSANADA", "Subsanada", "El operador subsana los requerimientos", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_REQUERIMIENTO_EN_COORDINACIÓN", "Requerimiento en coordinación", "El evaluador requiere uno o más documentos y está pendiente la aprobación del requerimiento por parte del coordinador", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_GENERANDO_RESOLUCIÓN", "Generando Resolución", "La solicitud fue aprobada por ambas entidades (MinTIC-ANE) y pasa al flujo de resolución", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_DEVOLUCIÓN_REQUERIMIENTO", "Devolución requerimiento", "El coordinador devuelve el requerimiento al evaluador para que vuelva a revisar", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_RESOLUCIÓN_GENERADA", "Resolución Generada", "El proyector genera la resolución", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_RESOLUCIÓN_APROBADA", "Resolución aprobada", "La resolución finaliza el flujo y se envia a IntegraTIC", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_RECHAZADA_PENDIENTE", "Rechazada Pendiente", "Solicitud aprobada por la ANE (CT generado) y rechazada por MinTIC. Pendiente de devolver el CT", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_DESISTIDA_TÁCITAMENTE_PENDIENTE", "Desistida Tácitamente Pendiente", "La fecha limite de subsanación se venció y la ANE puede aumentar el plazo de subsanación", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_DESISTIDA_PENDIENTE", "Desistida Pendiente", "La solicitud fue aprobada por la ANE y genero CT, y el operador la desiste. Pendiente devolver el CT", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_GENERANDO_OFICIO", "Generando Oficio", "La solicitud fue rechada por alguna de las dos entidades (MinTIC-ANE) y pasa al flujo de oficio", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_OFICIO_GENERADO", "Oficio Generado", "El proyector genera el oficio", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_OFICIO_APROBADO", "Oficio Aprobado", "El oficio finaliza el flujo, es aprobado y se envia para firma electrónica", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_DEVOLUCIÓN_RESOLUCIÓN", "Devolución Resolución", "El proceso esta en el flujo de resolución y se devuelve a la ANE para volver a revisar", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_RECHAZO_ADMINISTRATIVO", "Rechazo Administrativo", "La solicitud se rechaza por cartera, garantías, RUTIC u otro motivo general", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_RECHAZO_ADMINISTRATIVO_EN_COORDINACIÓN", "Rechazo Administrativo en coordinación", "El evaluador rechazo la solicitud por cartera, garantías, RUTIC u otro motivo general, y está pendiente la aprobación del rechazo por parte del coordinador", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_RECHAZO_EN_COORDINACIÓN", "Rechazo en coordinación", "El evaluador rechazo uno o más documentos y está pendiente la aprobación del rechazo por parte del coordinador", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_RESUMEN_TÉCNICO_GENERADO", "Resumen Técnico Generado", "La ANE genera el resumen técnico", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_REQUERIMIENTO_POR_CAMPOS", "Requerimiento por campos", "La ANE realiza un requerimiento por campos del anexo técnico", default, parent.Id as TermId),
            Term.Create("SOLICITUD_ESTADO_SUBSANACIÓN_POR_CAMPOS", "Subsanación por campos", "El operador realiza la subsanación del requerimiento por campos del anexo técnico realizado por la ANE", default, parent.Id as TermId));
    }
}