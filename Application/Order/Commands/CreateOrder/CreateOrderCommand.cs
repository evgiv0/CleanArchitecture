using MediatR;

namespace UseCases.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public CreateOrderDto Order { get; set; }
    }
}
