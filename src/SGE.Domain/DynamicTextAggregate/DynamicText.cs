using ErrorOr;

using SGE.Domain.Common.Models;
using SGE.Domain.DynamicTextAggregate.ValueObjects;

namespace SGE.Domain.DynamicTextAggregate;

public sealed class DynamicText(DynamicTextId id, string code, string text, string? description = null)
    : AggregateRoot<DynamicTextId>(id)
{
    public string Code { get; private set; } = code;
    public string Text { get; private set; } = text;
    public string? Description { get; private set; } = description;

    public static DynamicText Create(string code, string text, string? description = null)
    {
        return new DynamicText(DynamicTextId.CreateUnique(), code, text, description);
    }
}