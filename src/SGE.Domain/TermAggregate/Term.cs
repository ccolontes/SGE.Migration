using SGE.Domain.Common.Interfaces.Persistence;
using SGE.Domain.Common.Models;
using SGE.Domain.TermAggregate.ValueObjects;

namespace SGE.Domain.TermAggregate;

public class Term : AggregateRoot<TermId>, ISoftDeletable
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string? Slug { get; set; }

    public TermId? ParentId { get; set; }
    public Term? Parent { get; set; }

    private List<Term> _terms = new();

    public IReadOnlyList<Term> Terms => _terms.AsReadOnly();

    public Term(TermId id, string code, string name, string? description, string? slug, TermId? parent)
    {
        this.Id = id;
        this.Code = code;
        this.Name = name;
        this.Description = description;
        this.Slug = slug;
        this.ParentId = parent;
    }

    public static Term Create(string code, string name, string? description, string? slug, TermId? parent)
    {
        return new Term(TermId.CreateUnique(), code, name, description, slug, parent);
    }

    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }

    #pragma warning disable CS8618
    public Term() { }
    #pragma warning restore CS8618
}