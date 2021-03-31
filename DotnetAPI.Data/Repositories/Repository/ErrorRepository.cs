using dotnetAPI.Model.Models;
using DotnetAPI.Data.Infrastructure;
using DotnetAPI.Data.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAPI.Data.Repositories
{
  
    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {

        public ErrorRepository(DotnetAPIDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
