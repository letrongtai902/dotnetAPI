using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetAPI.Service.AccessRequestMediator
{
    public class PostAcessRequest<T>: IRequest
        where T : class
    {
        public T Value { get; set; }
    }
}
