using DojoCourse.Module.EventHandlers;
using Orchard.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoCourse.Module.Services
{
    public class BackgroundTask : IBackgroundTask
    {
        private readonly IBackgroundEventHandler _eventHandler;


        public BackgroundTask(IBackgroundEventHandler eventHandler)
        {
            _eventHandler = eventHandler;
        }


        public void Sweep()
        {
            _eventHandler.BackgroundTaskRun();
        }
    }
}