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
        T GetById(int id);
        IQueryable<T> GetAll(string[] includes = null);
        int Count(Expression<Func<T, bool>> where);

    }
}
