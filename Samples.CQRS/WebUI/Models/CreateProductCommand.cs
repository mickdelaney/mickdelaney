using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MD.Samples.CQRS.Orders.WebApp.Models
{
    public class CreateProductCommand
    {
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}