using dotnetAPI.Model;
using dotnetAPI.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace dotnetAPI.Host.Controllers
{
    [RoutePrefix("api/LogError")]
    public class LogErrorController: ApiController
    {
        private readonly ILogErrorService _logErrorService;
        public LogErrorController(ILogErrorService logErrorService) :
          base()
        {
            _logErrorService = logErrorService;

        }
        [Route("create")]
        [HttpPost]
        public void Create(LogError logError)
        {
            _logErrorService.Create(logError);
        }
    }
}