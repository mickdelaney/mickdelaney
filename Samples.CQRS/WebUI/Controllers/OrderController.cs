using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NServiceBus;
using MD.Samples.CQRS.Orders.Messages;
using MD.Mvc2.WebApp.Models;
using MD.Samples.CQRS.Orders.WebApp.Controllers;
using MD.Mvc2.WebApp.Core;
using MD.Samples.CQRS.Orders.Domain;
using MD.Samples.CQRS.Orders.Query;

namespace MD.Mvc2.WebApp.Controllers
{
    public class OrderController : Controller
    {
        OrderQuery _orderQuery;
        IBus _bus;

        public OrderController(IBus bus, OrderQuery orderQuery) 
        {
            _orderQuery = orderQuery;
            _bus = bus;
        } 

        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// Do we need to conditionally display a different UI based on the state of the order.
        /// UDI always says use email here. i.e. send them the URL in an email. 
        /// But could be also send them the link to the Order Id now and then use it since we 
        /// have generated the order id in the client and added it to the command.
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(Guid id)
        {
            return View(_orderQuery.Get(id));
        }

        public ActionResult Create()
        {
            return View(new OrderCommand());
        } 

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(OrderCommand command)
        {
            try
            {
                var token = Guid.NewGuid();
                _bus.Send(new OrderPlacedMessage { OrderId = token, EmailAddress = command.EmailAddress, Product = command.Product });



                return this.RedirectToAction<OrderController>(c => c.Details(token));
            }
            catch
            {
                return View();
            }
        }
    }
}
