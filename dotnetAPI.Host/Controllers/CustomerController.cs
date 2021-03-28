using Dapper;
using dotnetAPI.Host.Base;
using dotnetAPI.Model.Models;
using dotnetAPI.Service;
using DotnetAPI.Data;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;

namespace dotnetAPI.Host.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : BaseApiController
    {
        ICustomerService _customerService;
        public CustomerController(IErrorService errorService, ICustomerService customerService) :
           base(errorService)
        {
            _customerService = customerService;
        }



        [Route("create")]
        [HttpPost]
        public void Create(Customer customer)
        {
            _customerService.Add(customer);
            _customerService.Commit();

        }



        [Route("update")]
        [HttpPut]
        public void Update(Customer customer)
        {
            _customerService.Update(customer);
        }



        [Route("delete")]
        [HttpDelete]
        public void Delete(int ID)
        {
            _customerService.Delete(ID);
            _customerService.Commit();
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
        public IHttpActionResult Get(string FullName)
        {
            using(DotnetAPIDbContext db = new DotnetAPIDbContext())
            {
                var result = from value in db.Customers
                             where value.FullName == FullName
                             select value;
                return Json(result);
            }
        }

        [Route("getWithDapper")]
        [HttpGet]
        public IHttpActionResult GetUseDapper(string Email,string FullName)
        {
            
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbdotnetDemoAPI"].ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@FullName", FullName);
                p.Add("@Email", Email);
                var result = db.Query<Customer>("SelectAllCustomers", p , commandType: CommandType.StoredProcedure);
                return Json(result);
            }
        }

    }
}
