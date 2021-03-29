using dotnetAPI.Model.Models;
using DotnetAPI.Data;
using DotnetAPI.Data.Infrastructure;
using DotnetAPI.Data.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace dotnetAPI.Service
{
    public interface ICustomerService
    {
        void Add(Customer Customer);
        void Delete(int Id);
        void Update(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer GetById(int Id);
        IQueryable<Customer> GetWithLinq(string FullName);
        IEnumerable<Customer> GetWithDapper(string Email, string FullName);
        void Commit();
    }
    public class CustomerService : ICustomerService
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DbdotnetDemoAPI"].ConnectionString;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(Customer Customer)
        {
            _customerRepository.Add(Customer);
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public void Delete(int Id)
        {
            _customerRepository.Delete(Id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(int Id)
        {
            return _customerRepository.GetById(Id);
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
            using (DotnetAPIDbContext db = new DotnetAPIDbContext())
            {
                var result = from value in db.Customers
                             where value.FullName == FullName
                             select value;
                return result;
            }
        }



        public void Update(Customer customer)
        {
            _customerRepository.Update(customer);
        }
    }
}
