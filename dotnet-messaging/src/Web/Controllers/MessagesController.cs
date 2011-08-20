using System.Linq;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class MessagesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var messages = App.Messages;

            if (Request.IsAjaxRequest())
            {
                return Json(messages, JsonRequestBehavior.AllowGet);
            }

            return View(messages);
        }


        [HttpGet]
        public ActionResult Edit(string id)
        {
            var message = App.Messages.Where(m => m.Name == id);

            if (Request.IsAjaxRequest())
            {
                return Json(message);
            }

            return View(message);
        }
    }
}
