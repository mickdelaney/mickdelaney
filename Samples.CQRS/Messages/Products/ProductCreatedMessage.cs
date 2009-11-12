using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace MD.Samples.CQRS.Orders.Messages
{
    public class ProductCreatedMessage : IMessage
    {
        public Guid ProductId { get; set; }
    }
}
