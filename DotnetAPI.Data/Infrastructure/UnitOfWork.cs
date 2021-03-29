using dotnetAPI.Model.Models;
using DotnetAPI.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAPI.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DotnetAPIDbContext _dbContext;
        private CustomerRepository _customers;
        public UnitOfWork(DotnetAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IRepository<Customer> Customers
        {
            get
            {
                if(_customers == null)
                {
                    _customers = new CustomerRepository(_dbContext);
                }
                return _customers;
            }
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
