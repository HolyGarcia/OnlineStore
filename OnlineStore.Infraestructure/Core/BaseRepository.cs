using OnlineStore.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineStore.Infraestructure.Core
{
    public abstract class BaseRepository<TEntity> : Domain.Repository.IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public Task<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<TEntity>> getAll()
        {
            throw new NotImplementedException();
        }
        public Task<TEntity> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }
        public Task Save(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task Save(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }
        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task Update(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }
    }
}
