using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MD.Samples.CQRS.Orders.WebApp.Controllers
{
    [RequireCart]
    public class ControllerBase : Controller
    {
    }
}