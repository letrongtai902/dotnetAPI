using dotnetAPI.Model.Models;
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
        void Commit();
    }
}
