using MediatR;
using System;
using dotnetAPI.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetAPI.Service.Commands.Customers
{
    public class GetRequest: IRequest<Customer>
    {
        public int ID { get; set; }
    }
}
