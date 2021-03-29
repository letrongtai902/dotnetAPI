using dotnetAPI.Model.Models;
using DotnetAPI.Data.Infrastructure;

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
