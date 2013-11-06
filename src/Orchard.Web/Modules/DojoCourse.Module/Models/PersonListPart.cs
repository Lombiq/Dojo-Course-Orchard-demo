using Orchard.ContentManagement;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;
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
            get
            {
                var infosetValue = this.As<InfosetPart>().Get("PersonListPart", "MaxCount");
                if (infosetValue == null) return 0;
                return int.Parse(infosetValue);
            }
            set
            {
                this.As<InfosetPart>().Set("PersonListPart", "MaxCount", value.ToString());
                Record.MaxCount = value;
            }
        }
    }

    [OrchardFeature("DojoCourse.Module.Contents")]
    public class PersonListPartRecord : ContentPartRecord
    {
        public virtual int MaxCount { get; set; }
    }
}