
using dotnetAPI.Host.Base;
using dotnetAPI.Model;
using dotnetAPI.Model.Models;
using dotnetAPI.Service.IService;
using System;
using System.Web.Http;

namespace dotnetAPI.Host.Controllers
{

    [RoutePrefix("api/customer")]
    public class CustomerController : BaseApiController
    {
        
        ICustomerService _customerService;
        private readonly ILogErrorService _logErrorService;
        private readonly IErrorService _errorService;
        public CustomerController( ICustomerService customerService, ILogErrorService logErrorService, IErrorService errorService):
           base()
        {
            _customerService = customerService;
            _logErrorService = logErrorService;
            _errorService = errorService;
            
        }
        private void LogError(Exception e)
        {
            LogError logError = new LogError();
            logError.Message = e.Message;
            logError.StackTrace = e.StackTrace;
            logError.CreatedDate = DateTime.Now;
            _logErrorService.Create(logError);
        }
        private void Log(Exception ex)
        {
            Error e = new Error();
            e.Message = ex.Message;
            e.CreatedDate = DateTime.Now;
            e.StackTrace = ex.StackTrace;

            _errorService.Create(e);
            _errorService.Commit();
        }

        [Route("create")]
        [HttpPost]
        public void Create(Customer customer)
        {
            try
            {
                _customerService.Add(customer);
                _customerService.Commit();
            }
            catch(Exception ex)
            {
                LogError(ex);
                Log(ex);
            }  
        }



        [Route("update")]
        [HttpPut]
        public void Update(Customer customer)
        {
            try
            {
                _customerService.Update(customer);
                _customerService.Commit();
            }
            catch(Exception ex)
            {
                LogError(ex);
                Log(ex);
            }
            
        }

        [Route("delete")]
        [HttpDelete]
        public void Delete(int ID)
        {
            try
            {
                _customerService.Delete(ID);
                _customerService.Commit();
            }
            catch(Exception ex)
            {
                LogError(ex);
                Log(ex);
            }
        }

        [Route("getall")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(_customerService.GetAll());
        }

        [Route("getbyid")]
        [HttpGet]
        public IHttpActionResult Get(int Id)
        {
            return Json(_customerService.GetById(Id));
        }

        [Route("getwithlinq")]
        [HttpGet]
        public IHttpActionResult GetUseLinq(string FullName)
        {
            return Json(_customerService.GetWithLinq(FullName));
        }

        [Route("getWithDapper")]
        [HttpGet]
        public IHttpActionResult GetUseDapper(string Email, string FullName)
        {

            return Json(_customerService.GetWithDapper(Email, FullName));
        }

    }
}
