﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MD.Samples.CQRS.Orders.Domain;

namespace MD.Samples.CQRS.WebApp.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }

        public static Cart Empty()
        {
            return new Cart(new List<CartItem>());
        }

        public Cart(List<CartItem> items)
        {
            this.Items = items;
        }
    }
}