using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace MD.Samples.CQRS.Orders.Messages.Shop
{
    public class AddToCartMessage : IMessage
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
    }
}
