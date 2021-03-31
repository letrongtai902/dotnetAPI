using dotnetAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetAPI.Service.IService
{
    public interface ICustomerService
    {
        void Add(Customer Customer);
        void Delete(int Id);
        void Update(Customer customer);
        void Commit();
        IEnumerable<Customer> GetAll();
        Customer GetById(int Id);
        IQueryable<Customer> GetWithLinq(string FullName);
        IEnumerable<Customer> GetWithDapper(string Email, string FullName);
    }
}
