using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD.Samples.CQRS.Orders.Query
{
    public class CartItemDTO
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }

        public CartItemDTO()
        {
        }
    }
}