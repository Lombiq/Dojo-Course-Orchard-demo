using Orchard.Environment.Extensions;
using Orchard.Localization;
using Orchard.UI.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoCourse.Module
{
    [OrchardFeature("DojoCourse.Module.Contents")]
    public class AdminMenu : INavigationProvider
    {
        public string MenuName
        {
            get { return "admin"; }
        }

        public Localizer T { get; set; }


        public AdminMenu()
        {
            T = NullLocalizer.Instance;
        }


        public void GetNavigation(NavigationBuilder builder)
        {
            builder
                .Add(T("Person list dashboard"), "10", BuildMenu);
        }

        private void BuildMenu(NavigationItemBuilder menu)
        {
            menu.Action("PersonListDashboard", "ContentsAdmin", new { Area = "DojoCourse.Module" });
            menu.Add(T("Person list query"), "1", itemBuilder => itemBuilder
                .Action("PersonListQuery", "ContentsAdmin", new { Area = "DojoCourse.Module" }));
        }
    }
}