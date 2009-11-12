using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace MD.Samples.CQRS.Orders.Domain
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().UnsavedValue("00000000-0000-0000-0000-000000000000");
            Map(p => p.EmailAddress);
        }
    }
}
