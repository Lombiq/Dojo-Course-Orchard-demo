using Orchard.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoCourse.Module.DecoupledEventHandler
{
    public interface IBackgroundEventHandler : IEventHandler
    {
        void BackgroundTaskRun();
    }


    public class DecoupledEventHandler : IBackgroundEventHandler
    {
        public void BackgroundTaskRun()
        {
            var z = "blabla";
            var y = z;
        }
    }
}