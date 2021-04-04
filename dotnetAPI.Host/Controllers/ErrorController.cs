using dotnetAPI.Host.Base;
using dotnetAPI.Model.Models;
using dotnetAPI.Service.AccessRequestMediator;
using dotnetAPI.Service.IService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dotnetAPI.Host.Controllers
{
    [RoutePrefix("api/Error")]
    public class ErrorController : BaseApiController
    {
        private readonly IErrorService _errorService;
        public ErrorController(IErrorService errorService) :
          base()
        {
            _errorService = errorService;

        }
        [Route("create")]
        [HttpPost]
        public void Create(Error logError)
        {
            _errorService.Create(logError);
            _errorService.Commit();
            
        }
    }
}
