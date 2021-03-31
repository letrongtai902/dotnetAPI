using Dapper;
using dotnetAPI.Model.Models;
using DotnetAPI.Data.Infrastructure;
using DotnetAPI.Data.Repositories.IRepository;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DotnetAPI.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DbdotnetDemoAPI"].ConnectionString;
        public CustomerRepository(DotnetAPIDbContext dbcontext)
            : base(dbcontext)
        {

        }
        public IEnumerable<Customer> GetWithDapper(string Email, string FullName)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@FullName", FullName);
                p.Add("@Email", Email);
                var result = db.Query<Customer>("SelectAllCustomers", p, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public IQueryable<Customer> GetWithLinq(string FullName)
        {
            using(DotnetAPIDbContext db = new DotnetAPIDbContext())
            {
                var result = from value in db.Customers
                             where value.FullName == FullName
                             select value;
                return result;
            }
        }
    }
}
