using DojoCourse.Module.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoCourse.Module.Drivers
{
    [OrchardFeature("DojoCourse.Module.Contents")]
    public class PersonListPartDriver : ContentPartDriver<PersonListPart>
    {
        protected override DriverResult Display(PersonListPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_PersonList",
                () =>
                {
                    var displayTypeInCaps = displayType.ToUpper();
                    return shapeHelper.Parts_PersonList(DisplayTypeInCaps: displayTypeInCaps);
                });
        }

        protected override DriverResult Editor(PersonListPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_PersonList_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts.PersonList",
                    Model: part,
                    Prefix: Prefix));
        }

        protected override DriverResult Editor(PersonListPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(PersonListPart part, ExportContentContext context)
        {
            // <PersonListPart MaxCount="10" />
            var element = context.Element(part.PartDefinition.Name);

            element.SetAttributeValue("MaxCount", part.MaxCount);
        }

        protected override void Importing(PersonListPart part, ImportContentContext context)
        {
            var partName = part.PartDefinition.Name;

            context.ImportAttribute(partName, "MaxCount", value => part.MaxCount = int.Parse(value));
        }
    }
}