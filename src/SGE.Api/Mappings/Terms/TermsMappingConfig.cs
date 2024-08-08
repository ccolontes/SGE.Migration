using Mapster;

using SGE.Contracts.Terms;
using SGE.Domain.TermAggregate;

namespace SGE.Api.Mappings.Terms;

public class TermsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Term, TermResponse>()
            .Map(
                dest => dest.Id,
                src => src.Id.Value.ToString());
    }
}