using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Abstract.Interface
{
    public interface IModule
    {
        int ErrorCode { get; }
        string Message { get; }
    }
}
