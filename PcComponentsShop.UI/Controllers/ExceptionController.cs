using System.Web.Mvc;

namespace PcComponentsShop.UI.Controllers
{
    public class ExceptionController : Controller
    { 
        public ActionResult NotFoundException()
        {
            return View("NotFoundException");
        }
        public ActionResult CommonException()
        {
            return View("_Exception");
        }
    }
}