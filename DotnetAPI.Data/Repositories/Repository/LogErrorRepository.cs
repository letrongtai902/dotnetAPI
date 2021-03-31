using dotnetAPI.Model;
using DotnetAPI.Data.Repositories.IRepository;

namespace DotnetAPI.Data.Repositories
{
    public class LogErrorRepository :ILogErrorRepository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public LogErrorRepository()
        {

        }
        public void createLog(LogError logerror)
        {
            log.Info(logerror.Message);
        }
    }
}
