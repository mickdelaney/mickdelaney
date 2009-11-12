using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD.Samples.CQRS.Orders.Domain
{
    public interface IProductRepository
    {
        Product Save(Product product);
    }
}
