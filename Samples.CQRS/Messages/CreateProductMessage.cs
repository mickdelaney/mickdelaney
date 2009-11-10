using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace MD.Samples.CQRS.Orders.Messages
{
    public class CreateProductMessage : IMessage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
