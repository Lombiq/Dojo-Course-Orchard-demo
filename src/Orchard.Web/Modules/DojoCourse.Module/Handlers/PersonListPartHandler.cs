using DojoCourse.Module.Models;
using DojoCourse.Module.Services;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment;
using Orchard.Environment.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoCourse.Module.Handlers
{
    [OrchardFeature("DojoCourse.Module.Contents")]
    public class PersonListPartHandler : ContentHandler
    {
        public PersonListPartHandler(IRepository<PersonListPartRecord> repository, Work<IPersonManager> personManagerWork)
        {
            Filters.Add(StorageFilter.For(repository));

            OnActivated<PersonListPart>((context, part) =>
                {
                    part.PersonsField.Loader(() => personManagerWork.Value.GetPersons());
                });
        }
    }
}