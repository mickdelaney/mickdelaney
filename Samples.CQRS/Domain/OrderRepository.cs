using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD.Samples.CQRS.Order.Domain
{
    public class OrderRepository : IOrderRepository
    {
        public Order Save(Order order)
        {
            Console.WriteLine("Order saved {0}", order);
            return order;
        }
    }
}
