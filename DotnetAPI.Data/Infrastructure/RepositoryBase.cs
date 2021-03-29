using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DotnetAPI.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        internal DotnetAPIDbContext context;
        internal DbSet<T> dbSet;
        public RepositoryBase(DotnetAPIDbContext dbcontext)
        {
            context = dbcontext;
            dbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }


        public virtual void Delete(int Id)
        {
            var value = dbSet.Find(Id);
            dbSet.Remove(value);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T,bool>> where, string includes)
        {
            return dbSet.Where(where).ToList();
        }

        public virtual int Count(Expression<Func<T,bool>> where)
        {
            return dbSet.Count(where);
        }

        public IQueryable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count()>0)
            {
                var query = context.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }
            return context.Set<T>().AsQueryable();
        }
    }
}
