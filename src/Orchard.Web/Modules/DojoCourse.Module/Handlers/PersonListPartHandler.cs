using DojoCourse.Module.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
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
        public PersonListPartHandler(IRepository<PersonListPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}