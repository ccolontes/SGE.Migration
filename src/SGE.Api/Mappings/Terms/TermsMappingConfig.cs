using Mapster;

using SGE.Contracts.Terms;
using SGE.Domain.TermAggregate;

namespace SGE.Api.Mappings.Terms;

public class TermsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Dictionary<string, IReadOnlyList<Term>>, Dictionary<string, IReadOnlyList<TermResponse>>>()
            .Map(
                dest => dest,
                src => src.ToDictionary(
                    x => x.Key,
                    x => x.Value.Select(y => y.Adapt<TermResponse>())
                        .ToList()));
    }
}