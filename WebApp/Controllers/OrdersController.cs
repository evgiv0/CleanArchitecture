using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UseCases;
using UseCases.Order.Commands.CreateOrder;
using UseCases.Order.Queries.GetOrderById;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _sender;

        public OrdersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> Get(int id)
        {
            return await _sender.Send(new GetOrderByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateOrderDto order)
        {
            return await _sender.Send(new CreateOrderCommand { Order = order });
        }

    }
}
