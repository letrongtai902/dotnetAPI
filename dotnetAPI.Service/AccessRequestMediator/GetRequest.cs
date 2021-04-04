using MediatR;

namespace dotnetAPI.Service.AccessRequestMediator
{
    public class GetRequest<T> : IRequest<T>
    where T : class
    {
        public int ID { get; set; }
    }
}
