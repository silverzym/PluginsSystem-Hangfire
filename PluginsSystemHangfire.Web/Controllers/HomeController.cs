
using Abp.UI;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PluginsSystemHangfire.Web.Controllers
{
    public class HomeController : PluginsSystemHangfireControllerBase
    {
        public ActionResult Index()
        {
            return Content("Test");
        }
	}
}