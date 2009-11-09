using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace MD.Mvc2.WebApp.Models
{
    public class OrderCommand
    {
        [DisplayName("Email")]
        public string EmailAddress { get; set; }
        public string Product { get; set; }
    }
}