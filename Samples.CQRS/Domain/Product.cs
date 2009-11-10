using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD.Samples.CQRS.Orders.Domain
{
    public class Product : Entity
    {
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
    }
}
