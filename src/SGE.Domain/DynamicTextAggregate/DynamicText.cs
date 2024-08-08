using ErrorOr;

using SGE.Domain.Common.Interfaces.Persistence;
using SGE.Domain.Common.Models;
using SGE.Domain.DynamicTextAggregate.ValueObjects;
using SGE.Domain.TermAggregate.ValueObjects;

namespace SGE.Domain.DynamicTextAggregate;

public sealed class DynamicText
    : AggregateRoot<DynamicTextId>, ISoftDeletable
{
    public string Code { get; set; }
    public string Text { get; set; }
    public string? Description { get; set; }

    private DynamicText(DynamicTextId id, string code, string text, string? description)
    {
        Id = id;
        Code = code;
        Text = text;
        Description = description;
    }

    public static DynamicText Create(string code, string text, string? description = null)
    {
        return new DynamicText(DynamicTextId.CreateUnique(), code, text, description);
    }

    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }

    #pragma warning disable CS8618
    private DynamicText()
    {
    }
    #pragma warning restore CS8618
}