using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> Items { get; set; }

    }
}
