using dotnetAPI.Model;
using dotnetAPI.Service.IService;
using MediatR;
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
        private readonly IMediator _mediator;
        public LogErrorController(ILogErrorService logErrorService,IMediator mediator) :
          base()
        {
            _logErrorService = logErrorService;
            _mediator = mediator;

        }
        [Route("create")]
        [HttpPost]
        public void Create(LogError logError)
        {
            _logErrorService.Create(logError);
        }
    }
}