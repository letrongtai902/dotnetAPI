using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAPI.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int Id);
        void DeleteMulti(Expression<Func<T, bool>> where);
        T GetSingleById(int id);
        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        IQueryable<T> GetAll(string[] includes = null);
        IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);
        int Count(Expression<Func<T, bool>> where);

    }
}
