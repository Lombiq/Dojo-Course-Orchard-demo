using Orchard.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoCourse.Module.EventHandlers
{
    public interface IBackgroundEventHandler : IEventHandler
    {
        void BackgroundTaskRun();
    }
}
