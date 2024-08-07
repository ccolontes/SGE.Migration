namespace SGE.Contracts.Terms;

public record TermResponse(string Id, string Code, string Name, string? Description, string? Slug);