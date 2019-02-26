using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SibersTest.DAL.EF;
using System.Data.Entity;
using System.Linq.Expressions;

namespace SibersTest.DAL.Infrastructure
{
    class RepositoryBase<T> : IRepository<T> where T : class
    {
        private ProjectDbContext dbContext;
        private IDbSet<T> dbSet;

        public RepositoryBase(ProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            var entityEntry = dbContext.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            entityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }
    }
}
