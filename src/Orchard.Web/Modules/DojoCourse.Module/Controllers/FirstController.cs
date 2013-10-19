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
        public ViewResult Index(string userName)
        {
            return View();
        }
    }
}