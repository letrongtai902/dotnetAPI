using dotnetAPI.Model.Models;
using DotnetAPI.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAPI.Data.Repositories.IRepository
{
    public interface IErrorRepository: IRepository<Error>
    {
    }
}
