using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD.Samples.CQRS.Orders.Domain
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Product Product { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
    }
}
