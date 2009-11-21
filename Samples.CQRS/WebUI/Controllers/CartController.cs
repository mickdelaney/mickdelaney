using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MD.Samples.CQRS.Orders.Query;
using NServiceBus;
using MD.Samples.CQRS.Orders.Domain;
using MD.Samples.CQRS.Orders.Messages.Shop;
using MD.Samples.CQRS.WebApp.Models;

namespace MD.Samples.CQRS.Orders.WebApp.Controllers
{
    public class CartController : Controller
    {
        CartQuery _cartQuery;
        ProductQuery _productQuery;
        IBus _bus;

        public CartController(IBus bus, CartQuery cartQuery, ProductQuery productQuery) 
        {
            _cartQuery = cartQuery;
            _productQuery = productQuery;
            _bus = bus;
        }

        public ActionResult Add(Guid Id)
        {
            TempData["Message"] = "Adding To Cart...";

            //query our cart service, display products.
            var product = _productQuery.Get(Id);

            var item = new AddToCartMessage 
            {
                UserId = new Guid(Request.AnonymousID),
                Quantity = 1,
                ProductId = Id,
                Value = product.Price
            };

            _bus.Send(item);

            if (Request.IsAjaxRequest())
            {
                return View("CartViewControl", GetCartForCurrentUser());
            }
            else
            {
                return this.RedirectToAction("Index");
            }
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

            //Show me my cart. Who am i? 
            var items = _cartQuery.GetCartForUser(new Guid(Request.AnonymousID));
            if (items == null)
            {
                return View(Cart.Empty());
            }





            //if (Request.Cookies["hnet-user-data"] != null)
            //{
            //    //We have created a session for this guy. he must have added something??
            //    var cookie = Request.Cookies["hnet-user-data"];
            //    if (cookie.Values["cart-id"] != null)
            //    {
                    
            //    }

            //}


            return View(new Cart(items));
        }

        public ActionResult Get()
        {
            var cart = GetCartForCurrentUser();

            if (Request.IsAjaxRequest())
            {
                return View("CartViewControl", cart);
            }
            
            return this.RedirectToAction("Index");
        }

        private Cart GetCartForCurrentUser()
        {
            var Id = new Guid(Request.AnonymousID);
            var items = _cartQuery.GetCartForUser(Id);
            return new Cart(items);
        }
    }
}