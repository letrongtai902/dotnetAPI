using dotnetAPI.Model;
using dotnetAPI.Service.IService;
using DotnetAPI.Data.Repositories.IRepository;

namespace dotnetAPI.Service
{

    public class LogErrorService: ILogErrorService
    {
        
        private readonly ILogErrorRepository _logErrorRepository;
   
        public LogErrorService(ILogErrorRepository logErrorRepository)
        {
            _logErrorRepository = logErrorRepository;
        }

        public void Create(LogError error)
        {
            _logErrorRepository.createLog(error);
        }
    }
}
