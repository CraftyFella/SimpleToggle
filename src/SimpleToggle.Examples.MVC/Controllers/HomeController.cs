using System.Web.Mvc;

namespace SimpleToggle.Examples.MVC.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Get()
        {
            return View();
        }
    }
}