using System.Linq;
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
                On = Feature.IsEnabled(name)
            }, JsonRequestBehavior.AllowGet);
        }

        [Route("toggle")]
        [HttpGet]
        public ActionResult Get()
        {
            var toggles = Feature.All.Select(t => new { name = t, on = Feature.IsEnabled(t) }).ToArray();
            return Json(new { toggles }, JsonRequestBehavior.AllowGet);
        }
    }
}