﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD.Samples.CQRS.Orders.Domain
{
    public class Order : Entity
    {
        public virtual User Customer { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
