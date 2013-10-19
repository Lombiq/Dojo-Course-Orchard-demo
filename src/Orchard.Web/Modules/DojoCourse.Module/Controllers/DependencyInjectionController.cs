using Orchard;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.Mvc;
using Orchard.UI.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DojoCourse.Module.Controllers
{
    public class DependencyInjectionController : Controller
    {
        private IWorkContextAccessor _wca;
        private IHttpContextAccessor _hca;
        private INotifier _notifier;

        public Localizer T { get; set; }

        public ILogger Logger { get; set; }


        public DependencyInjectionController(
            IWorkContextAccessor wca, 
            IHttpContextAccessor hca,
            INotifier notifier)
        {
            _wca = wca;
            _hca = hca;
            _notifier = notifier;

            T = NullLocalizer.Instance;
            Logger = NullLogger.Instance;
        }


        public ActionResult Index()
        {
            var workContext = _wca.GetContext();
            var httpContext = _hca.Current();

            if (workContext.CurrentUser != null)
            {
                _notifier.Information(T("Hello {0}!", workContext.CurrentUser.UserName));
                return RedirectToAction("Index", "First", new { Area = "DojoCourse.Module", UserName = workContext.CurrentUser.UserName }); 
            }
            else
            {
                Logger.Error("User was not logged in.");
                return RedirectToAction("Index", "First", new { Area = "DojoCourse.Module" }); 
            }
        }
    }
}