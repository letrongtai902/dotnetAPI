using dotnetAPI.Model.Models;
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
    public class PostHandler : IRequestHandler<PostRequest, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        public PostHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Task<Unit> Handle(PostRequest request, CancellationToken cancellationToken)
        {
            _customerRepository.Add(request.Value);
            return Task.FromResult(Unit.Value);
        }
    }
}
