using dotnetAPI.Model.Models;
using DotnetAPI.Data.Infrastructure;
using DotnetAPI.Data.Repositories;
using System;
using System.Collections.Generic;

namespace dotnetAPI.Service
{
    public interface ICustomerService
    {
        void Add(Customer Customer);
        void Delete(int Id);
        void Update(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer GetById(int Id);
        void Commit();
    }
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

        public void Update(Customer customer)
        {
            _customerRepository.Update(customer);
        }
    }
}
