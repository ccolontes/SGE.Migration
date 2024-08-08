namespace SGE.Contracts.Terms;

public record GetTermsByCodesResponse(Dictionary<string, List<TermResponse>> Terms);