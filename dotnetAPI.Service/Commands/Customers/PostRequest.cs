using dotnetAPI.Model.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetAPI.Service.Commands.Customers
{
    public class PostRequest:IRequest
    {
        public Customer Value { get; set; }
    }
}
