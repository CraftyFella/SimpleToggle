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

    public interface IUseToggles
    {
        string Message();
    }

    public class NoOpVersion : IUseToggles
    {
        public string Message()
        {
            return "Hello from Toggle Off Version";
        }
    }

    public class ToggleOnVersion : IUseToggles
    {
        public string Message()
        {
            return "Hello from Toggle On Version";
        }
    }
}