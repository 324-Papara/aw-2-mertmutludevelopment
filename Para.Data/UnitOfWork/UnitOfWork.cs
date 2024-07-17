using Para.Base.Entity;
using Para.Data.Context;
using Para.Data.GenericRepository;
namespace Para.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ParaPostgreDbContext dbContext;
        private readonly Dictionary<Type, object> repositories;

        public UnitOfWork(ParaPostgreDbContext dbContext)
        {
            this.dbContext = dbContext;
            repositories = new Dictionary<Type, object>();
        }

        public async Task Complete()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task CompleteWithTransaction()
        {
            await using var dbTransaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                await dbContext.SaveChangesAsync();
                await dbTransaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await dbTransaction.RollbackAsync();
                Console.WriteLine(ex);
                throw;
            }
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (repositories.ContainsKey(typeof(TEntity)))
            {
                return repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            var repositoryInstance = new GenericRepository<TEntity>(dbContext);
            repositories.Add(typeof(TEntity), repositoryInstance);
            return repositoryInstance;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}