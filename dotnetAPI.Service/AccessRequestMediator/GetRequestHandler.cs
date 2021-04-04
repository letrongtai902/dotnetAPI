using DotnetAPI.Data;
using DotnetAPI.Data.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnetAPI.Service.AccessRequestMediator
{
    public class GetRequestHandler<T> : IRequestHandler<GetRequest<T>, T>
        where T : class
    {
        private readonly IRepository<T> _repository;
        public GetRequestHandler(IRepository<T> repository)
        {
            _repository = repository;
        }
        public Task<T> Handle(GetRequest<T> request, CancellationToken cancellationToken)
        {
            var result = _repository.GetById(request.ID);
            return Task.FromResult(result);
        }
    }
}
