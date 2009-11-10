using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD.Samples.CQRS.Orders.Query
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
