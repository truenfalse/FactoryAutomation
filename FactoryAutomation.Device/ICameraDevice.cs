using FactoryAutomation.Vision;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Device
{
    public interface ICameraDevice
    {
        event EventHandler GrabFail;
        event ImageEventHandler GrabCompleted;
        IImage GrabOne();
    }
}
