using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD.Samples.CQRS.Order.Query
{
    public class OrderQuery
    {
        public List<OrderDTO> GetOrders()
        {
            return new List<OrderDTO>();
        }

        public OrderDTO Get(Guid id)
        {
            return new OrderDTO { Id = id };
        }
    }
}
