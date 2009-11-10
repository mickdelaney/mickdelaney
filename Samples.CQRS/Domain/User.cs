using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD.Samples.CQRS.Orders.Domain
{
    public class User : Entity
    {
        public virtual string EmailAddress { get; set; }
    }
}
