using Microsoft.EntityFrameworkCore;

using SGE.Domain.Common.Interfaces.Persistence;

namespace SGE.Infrastructure.Common.Interfaces;

public interface IUnitOfWork<T> : IUnitOfWork
    where T : DbContext;