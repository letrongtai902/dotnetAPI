using dotnetAPI.Model.Models;
using dotnetAPI.Service.AccessRequestMediator;
using MediatR;
using dotnetAPI.Service.Commands.Customers;
using System.Threading.Tasks;
using System.Web.Http;


namespace dotnetAPI.Host.Controllers
{
    [RoutePrefix("api/customercqrs")]
    public class CustomerCQRSController : ApiController
    {
        private readonly IMediator _mediator;

        public CustomerCQRSController(IMediator mediator):
            base()
        {
            _mediator = mediator;
        }

        [Route("Postcustomer")]
        [HttpPost]

        public void PostCustomer(Customer customer)
        {
            _mediator.Send(new PostRequest { Value = customer });
        }

        [Route("Getcustomer")]
        [HttpGet]

        public IHttpActionResult Getcustomer(int ID)
        {
            return Json(_mediator.Send(new GetRequest { ID = ID }));
        }

    }
}
