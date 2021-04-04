using dotnetAPI.Model.Models;
using DotnetAPI.Data.Infrastructure;
using DotnetAPI.Data.Repositories;
using DotnetAPI.Data.Repositories.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnetAPI.Service.Commands.Customers
{
    public class Gethandler: IRequestHandler<GetRequest,Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public Gethandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Customer> Handle(GetRequest request, CancellationToken cancellationToken)
        {
            var cs = _customerRepository.GetById(request.ID);
            return Task.FromResult(cs);
        }
    }
}
