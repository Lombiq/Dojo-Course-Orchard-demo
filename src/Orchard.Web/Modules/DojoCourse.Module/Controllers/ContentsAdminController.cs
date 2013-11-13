using Orchard;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using Orchard.Mvc;
using Orchard.Security;
using Orchard.UI.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DojoCourse.Module.Controllers
{
    [OrchardFeature("DojoCourse.Module.Contents")]
    [Admin]
    public class ContentsAdminController : Controller
    {
        private readonly IOrchardServices _orchardServices;
        private readonly IAuthorizer _authorizer;
        private readonly IContentManager _contentManager;

        public Localizer T { get; set; }

        public ContentsAdminController(IOrchardServices orchardServices)
        {
            _orchardServices = orchardServices;
            _authorizer = orchardServices.Authorizer;
            _contentManager = orchardServices.ContentManager;

            T = NullLocalizer.Instance;
        }

        public ActionResult PersonListDashboard(int id = 0)
        {
            if (!IsAuthorized()) return new HttpUnauthorizedResult();

            var item = GetItem(id);
            if (item == null) return new HttpNotFoundResult();

            return PersonListDashboardShapeResult(item);
        }


        private ShapeResult PersonListDashboardShapeResult(ContentItem item)
        {
            var itemEditorShape = _contentManager.BuildEditor(item);

            var editorShape = _orchardServices.New.DojoCourse_PersonListDashboard(EditorShape: itemEditorShape);

            return new ShapeResult(this, editorShape);
        }

        private bool IsAuthorized()
        {
            return _authorizer.Authorize(Permissions.AccessPersonListDashboard, T("Sorry, you are not allowed to do that."));
        }

        private ContentItem GetItem(int id)
        {
            if (id == 0) return _contentManager.New("PersonList");
            else return _contentManager.Get(id);
        }
    }
}