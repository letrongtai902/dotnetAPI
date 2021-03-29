
using dotnetAPI.Host.Base;
using dotnetAPI.Model.Models;
using dotnetAPI.Service;
using System;
using System.Web.Http;

namespace dotnetAPI.Host.Controllers
{


    [RoutePrefix("api/customer")]
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IErrorService _errorService;
        public CustomerController(IErrorService errorService, ICustomerService customerService) :
           base()
        {
            _customerService = customerService;
            _errorService = errorService;
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
                Error result = new Error();
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
                result.CreatedDate = DateTime.Now;
                _errorService.Create(result);
                _errorService.Commit();
            }
            

        }



        [Route("update")]
        [HttpPut]
        public void Update(Customer customer)
        {
            try
            {
                _customerService.Update(customer);
            }
            catch(Exception ex)
            {
                Error result = new Error();
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
                result.CreatedDate = DateTime.Now;
                _errorService.Create(result);
                _errorService.Commit();
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
                Error result = new Error();
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
                result.CreatedDate = DateTime.Now;
                _errorService.Create(result);
                _errorService.Commit();
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
