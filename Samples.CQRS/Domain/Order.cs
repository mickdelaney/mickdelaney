﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD.Samples.CQRS.Order.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
    }
}
