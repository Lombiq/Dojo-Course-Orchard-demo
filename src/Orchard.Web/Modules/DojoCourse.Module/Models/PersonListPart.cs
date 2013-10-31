using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Environment.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoCourse.Module.Models
{
    [OrchardFeature("DojoCourse.Module.Contents")]
    public class PersonListPart : ContentPart<PersonListPartRecord>
    {
        public int MaxCount
        {
            get { return Record.MaxCount; }
            set { Record.MaxCount = value; }
        }
    }

    [OrchardFeature("DojoCourse.Module.Contents")]
    public class PersonListPartRecord : ContentPartRecord
    {
        public virtual int MaxCount { get; set; }
    }
}