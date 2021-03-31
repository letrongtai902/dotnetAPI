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
using DotnetAPI.Data.Repositories.IRepository;
using dotnetAPI.Service.IService;

namespace dotnetAPI.Service
{
    
    public class CustomerService : ICustomerService
    {
        
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(Customer Customer)
        {
            _unitOfWork.Customers.Add(Customer);
        }
        public void Delete(int Id)
        {
            _unitOfWork.Customers.Delete(Id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(int Id)
        {
            return _unitOfWork.Customers.GetById(Id);
        }

        public IEnumerable<Customer> GetWithDapper(string Email, string FullName)
        {
            return _customerRepository.GetWithDapper(Email,FullName);
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

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
