using dotnetAPI.Model.Models;
using DotnetAPI.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAPI.Data.Repositories
{
    public interface IErrorRepository : IRepository<Error>
    {
        
    }
    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {

        public ErrorRepository(DotnetAPIDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
