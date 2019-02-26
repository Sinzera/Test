using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.DAL.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
    }
}
