using System.Linq;
using System.Web.Mvc;
using Web.Models;

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

            var viewModel = new MessagesViewModel(messages);

            return View(viewModel);
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
