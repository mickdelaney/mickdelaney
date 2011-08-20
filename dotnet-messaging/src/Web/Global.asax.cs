using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Web.Core;
using Web.Models;

namespace Web
{
    public class App : HttpApplication
    {
        public static IList<Message> Messages = new List<Message>();

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RoutesBuilder.Install(routes);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            FillDefaultMessages();
        }

        void FillDefaultMessages()
        {
            Messages.Add(new Message(Guid.NewGuid(), "Contractor registered", "John Smith, London"));
            Messages.Add(new Message(Guid.NewGuid(), "Contractor registered", "Abdul Rahmen, Bangalore"));
            Messages.Add(new Message(Guid.NewGuid(), "Contractor registered", "Raheem Mulitear, Birmingham"));
            Messages.Add(new Message(Guid.NewGuid(), "Contractor registered", "Alan Dunne, Dublin"));
        }
    }
}