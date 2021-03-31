using dotnetAPI.Model;
using dotnetAPI.Model.Models;
using DotnetAPI.Data.Repositories;
using DotnetAPI.Data.Repositories.IRepository;

namespace DotnetAPI.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly DotnetAPIDbContext _dbContext;
        private ICustomerRepository _customers;
        private IErrorRepository _errorRepository;
        public UnitOfWork(DotnetAPIDbContext dbContext, IErrorRepository errorRepository, ICustomerRepository customer)
        {
            _customers = customer;
            _dbContext = dbContext;
            _errorRepository = errorRepository;
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
        public IRepository<Error> Errors {
            get
            {
                if(_errorRepository == null)
                {
                    _errorRepository = new ErrorRepository(_dbContext);
                }
                return _errorRepository;
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
