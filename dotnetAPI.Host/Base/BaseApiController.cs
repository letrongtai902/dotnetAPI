using dotnetAPI.Model.Models;
using dotnetAPI.Service;
using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dotnetAPI.Host.Base
{
    public class BaseApiController : ApiController
    {
        public IErrorService _errorService;
        public BaseApiController(IErrorService errorService)
        {
            _errorService = errorService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage result = null;
            try
            {
                result = function.Invoke();
            }
            catch(DbUpdateException dbex)
            {
                LogError(dbex);
                result = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbex.InnerException.Message);
            }
            catch(Exception ex)
            {
                LogError(ex);
                result = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return result;
            
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error error = new Error();
                error.Message = ex.Message;
                error.StackTrace = ex.StackTrace;
                error.CreatedDate = DateTime.Now;
                _errorService.Create(error);
                _errorService.Commit();
            }
            catch
            {

            }
        }
    }
}
