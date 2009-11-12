using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MD.Samples.CQRS.Orders.Domain;
using FluentNHibernate.Mapping;

namespace MD.Samples.CQRS.Data.Mappings
{
    public class CartItemMap : ClassMap<CartItem>
    {
        public CartItemMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().UnsavedValue("00000000-0000-0000-0000-000000000000");
            Map(x => x.UserId);
            Map(x => x.Value);
            Map(x => x.Quantity);
            References(x => x.Product);
            
        }


    }
}
