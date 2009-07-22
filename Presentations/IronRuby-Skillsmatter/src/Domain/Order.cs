using System;
using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public DateTime DeliveryDate { get; set; }
        public List<Product> Products  { get; set; }

        public double OrderTotal()
        {
            if(Products == null || Products.Count == 0)
            {
                return 0;
            }
            
            double orderTotal = 0;
            Products.ForEach(product => orderTotal += product.Price);
            return orderTotal;
        }
    }
}
