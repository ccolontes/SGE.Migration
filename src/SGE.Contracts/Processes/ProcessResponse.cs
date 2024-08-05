using SGE.Contracts.Procedures;

namespace SGE.Contracts.Processes;

public record ProcessResponse(string Id, string Name, List<ProcedureResponse> Procedures);