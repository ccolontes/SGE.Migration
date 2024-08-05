namespace SGE.Domain.Common.Interfaces.Persistence;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    DateTime? DeletedOnUtc { get; set;  }
}