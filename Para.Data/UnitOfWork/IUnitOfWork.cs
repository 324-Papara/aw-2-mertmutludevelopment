using Para.Base.Entity;
using Para.Data.GenericRepository;
using System;
using System.Threading.Tasks;

namespace Para.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task Complete();
        Task CompleteWithTransaction();
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    }
}