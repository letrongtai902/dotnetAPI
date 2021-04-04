using DotnetAPI.Data.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnetAPI.Service.AccessRequestMediator
{
    public class PostAcessRequestHandler<T> : IRequestHandler<PostAcessRequest<T>>
        where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public PostAcessRequestHandler(IRepository<T> repository,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(PostAcessRequest<T> request, CancellationToken cancellationToken)
        {
            _repository.Add(request.Value);
            _unitOfWork.Commit();
            return Task.FromResult(Unit.Value);
        }
    }
}
