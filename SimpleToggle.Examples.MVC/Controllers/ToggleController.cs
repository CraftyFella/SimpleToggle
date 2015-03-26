using System.Net;
using System.Web.Mvc;

namespace SimpleToggle.Examples.MVC.Controllers
{
    public class ToggleController : Controller
    {
        private readonly IToggler _toggler;

        public ToggleController(IToggler toggler)
        {
            _toggler = toggler;
        }

        [Route("toggle")]
        [HttpPost]
        public ActionResult Post(ToggleRequest request)
        {
            _toggler.Toggle(request.Name, request.On);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [Route("toggle/{name}")]
        [HttpGet]
        public ActionResult Get(string name)
        {
            return Json(new
            {
                Name = name,
                On = Toggle.Enabled(name)
            }, JsonRequestBehavior.AllowGet);
        }

        [Route("toggle")]
        [HttpGet]
        public ActionResult Get()
        {
            // TODO: I think toggles should be registered with the engine to allow us to list toggles (Registering could allow readonly or per request toggles)
            return Json(new { toggles = new []
            {
                new { name = "Toggle1", on = Toggle.Enabled("Toggle1") },
                new { name = "Toggle2", on = Toggle.Enabled("Toggle2") },
                new { name = "Toggle3", on = Toggle.Enabled("Toggle3") }
            }}, JsonRequestBehavior.AllowGet);
        }
    }
}