namespace SGE.Contracts.Terms;

public record GetTermsByCodesResponse(Dictionary<string, IReadOnlyList<TermResponse>> Terms);