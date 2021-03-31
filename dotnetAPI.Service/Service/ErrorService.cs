using dotnetAPI.Model.Models;
using dotnetAPI.Service.IService;
using DotnetAPI.Data;
using DotnetAPI.Data.Infrastructure;
using DotnetAPI.Data.Repositories.IRepository;

namespace dotnetAPI.Service
{

    public class ErrorService : IErrorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IErrorRepository _errorRepository;
        private readonly DotnetAPIDbContext _dbContext;
        public ErrorService(IUnitOfWork unitOfWork, IErrorRepository errorRepository, DotnetAPIDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _errorRepository = errorRepository;
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Create(Error error)
        {
            _unitOfWork.Errors.Add(error);

        }
    }
}
