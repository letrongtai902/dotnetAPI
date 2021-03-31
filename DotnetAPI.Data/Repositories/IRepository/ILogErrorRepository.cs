using dotnetAPI.Model;

namespace DotnetAPI.Data.Repositories.IRepository
{
    public interface ILogErrorRepository
    {
        void createLog(LogError logerror);
    }
}
