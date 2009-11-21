using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD.Samples.CQRS.Orders.Domain
{
    [Serializable]
    public class CartItem
    {
        public virtual Guid Id { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual Product Product { get; set; }
        public virtual double Value { get; set; }
        public virtual int Quantity { get; set; }
    }
}
