using Orchard;
using Orchard.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DojoCourse.Module.Controllers
{
    [Themed]
    public class FirstController : Controller
    {
        private IWorkContextAccessor _wca;


        public FirstController(IWorkContextAccessor wca)
        {
            _wca = wca;
        }


        public ViewResult Index()
        {
            var workContext = _wca.GetContext();
            var siteName = workContext.CurrentSite.SiteName;

            return View();
        }
    }
}