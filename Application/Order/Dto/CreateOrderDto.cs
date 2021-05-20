using System.Collections.Generic;

namespace UseCases
{
    public class CreateOrderDto
    {
        public List<OrderItemDto> Items { get; set; }
    }
}