using System.Web.Mvc;

namespace SimpleToggle.Examples.MVC.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IUseToggles _serviceThatUsesToggles;

        public ServiceController(IUseToggles serviceThatUsesToggles)
        {
            _serviceThatUsesToggles = serviceThatUsesToggles;
        }

        [Route("message")]
        public ActionResult Get()
        {
            return Json(new { message = _serviceThatUsesToggles.Message() }, JsonRequestBehavior.AllowGet);
        }
    }
}