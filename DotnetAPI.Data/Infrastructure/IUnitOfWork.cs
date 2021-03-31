using dotnetAPI.Model;
using dotnetAPI.Model.Models;
using DotnetAPI.Data.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAPI.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Customer> Customers { get; }
        IRepository<Error> Errors { get; }
        void Commit();
    }
}
