using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Abstract.Interface
{
    public interface IDevice
    {
        int ErrorCode { get; }
        string Message { get; }
        IParams DeviceParams { get; set; }
    }
}
