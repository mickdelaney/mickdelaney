using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NServiceBus;

namespace MD.Samples.CQRS.Orders.Messages.Shop
{
    public class SearchForProductMessage : IMessage
    {
        public Guid SearchCorrelationToken { get; set; }
        //public Expression<Func<Product, bool>> Match { get; set; }
    }
}
