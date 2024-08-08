using Mapster;

using SGE.Contracts.Procedures;
using SGE.Contracts.Processes;
using SGE.Domain.ProcessAggregate;

namespace SGE.Api.Mappings.Processes;

public class ProcessMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Process, ProcessResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(dest => dest.Name, src => src.Name);
    }
}