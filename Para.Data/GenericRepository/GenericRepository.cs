using Microsoft.EntityFrameworkCore;
using Para.Base.Entity;
using Para.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Para.Data.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ParaPostgreDbContext dbContext;

        public GenericRepository(ParaPostgreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task<TEntity?> GetById(long Id)
        {
            return await dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Insert(TEntity entity)
        {
            entity.IsActive = true;
            entity.InsertDate = DateTime.UtcNow;
            entity.InsertUser = "System";
            await dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task Delete(long Id)
        {
            var entity = await dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == Id);
            if(entity is not null)
                dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }
    }
}