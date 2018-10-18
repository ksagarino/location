using LocationAPI.Services;
using LocationAPI.Models;
using System.Collections.Generic;

using System;
using System.Linq;
using System.Data.Entity;

namespace LocationAPI.Repositories
{
    public class Repository<TEntity> : IRepositoryService<TEntity> where TEntity : class
    {
        private LocationDBEntities _dbContext;

        public Repository(LocationDBEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetByID(object id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbContext.Set<TEntity>().Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

       
    }
}