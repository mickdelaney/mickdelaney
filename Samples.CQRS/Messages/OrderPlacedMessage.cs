using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace MD.Samples.CQRS.Orders.Messages
{
    public class OrderPlacedMessage : IMessage
    {
        public Guid OrderId { get; set; }
        public string EmailAddress { get; set; }
        public string Product { get; set; }
    }
}
