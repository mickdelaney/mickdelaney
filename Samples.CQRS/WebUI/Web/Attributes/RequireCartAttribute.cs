using System.Web.Mvc;
using MD.Samples.CQRS.Orders.Query;
using Microsoft.Practices.ServiceLocation;
using System;
using MD.Samples.CQRS.WebApp.Models;


public class RequireCartAttribute : ActionFilterAttribute
{
    CartQuery _cartQuery;

    public RequireCartAttribute()
    {
        _cartQuery = ServiceLocator.Current.GetInstance<CartQuery>();
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (!(filterContext.Controller is Controller))
            return;
        
        var controller = (Controller)filterContext.Controller;

        //Show me my cart. Who am i? 
        var items = _cartQuery.GetCartForUser(new Guid(filterContext.RequestContext.HttpContext.Request.AnonymousID));
        if (items == null)
        {
            controller.ViewData.Add("Cart", Cart.Empty());
            return;
        }

        controller.ViewData.Add("Cart", new Cart(items));
    }
}