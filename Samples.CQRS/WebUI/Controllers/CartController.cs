using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MD.Samples.CQRS.Orders.Query;
using NServiceBus;
using MD.Samples.CQRS.Orders.Domain;

namespace MD.Samples.CQRS.Orders.WebApp.Controllers
{
    public class CartController : Controller
    {
        CartQuery _cartQuery;
        IBus _bus;

        public CartController(IBus bus, CartQuery cartQuery) 
        {
            _cartQuery = cartQuery;
            _bus = bus;
        } 

        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                //We have a user. Get its Id from here
            }

            if (string.IsNullOrEmpty(Request.AnonymousID))
            {
                //Use the anon id (guid)
            }

            //query our cart service, display products.

            var item = new CartItem();


            //Show me my cart. Who am i? 

            if (Request.Cookies["hnet-user-data"] != null)
            {
                //We have created a session for this guy. he must have added something??
                var cookie = Request.Cookies["hnet-user-data"];
                if (cookie.Values["cart-id"] != null)
                {
                    
                }

            }


            return View();
        }

    }
}