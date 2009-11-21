using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace MD.Samples.CQRS.Orders.Messages.Shop
{
    public class ItemAddedToCartMessage : IMessage
    {
        public Guid CartItemId { get; set; }
    }
}
