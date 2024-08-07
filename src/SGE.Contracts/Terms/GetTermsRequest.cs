namespace SGE.Contracts.Terms;

public record GetTermsRequest(ICollection<string> Codes);