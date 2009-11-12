using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace MD.Samples.CQRS.Orders.Domain
{
    public class OrderMap : ClassMap<Order> 
    {
        public OrderMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().UnsavedValue("00000000-0000-0000-0000-000000000000");
            References(x => x.Customer);
            HasManyToMany(x => x.Products);
        }
    }
}
