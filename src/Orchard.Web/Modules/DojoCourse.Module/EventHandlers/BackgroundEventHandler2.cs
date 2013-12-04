using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoCourse.Module.EventHandlers
{
    public class BackgroundEventHandler2 : IBackgroundEventHandler
    {
        public void BackgroundTaskRun()
        {
            var z = "blabla";
            var y = z;
        }
    }
}