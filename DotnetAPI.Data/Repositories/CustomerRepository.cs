using dotnetAPI.Model.Models;
using DotnetAPI.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAPI.Data.Repositories
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        
    }
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        
        public CustomerRepository(DotnetAPIDbContext dbcontext)
            : base(dbcontext)
        {

        }
    }
}
