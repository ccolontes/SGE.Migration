namespace SGE.Domain.ProcessAggregate.Interfaces;

public interface IProcessRepository
{
    Task<List<Process>> ListAsync(CancellationToken cancellationToken);
}