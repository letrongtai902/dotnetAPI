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
        IEnumerable<Customer> GetByFullName(string FullName);
    }
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        
        public CustomerRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<Customer> GetByFullName (string FullName)
        {
            return this.DbContext.Customers.Where(x => x.FullName == FullName);
        }
    }
}
