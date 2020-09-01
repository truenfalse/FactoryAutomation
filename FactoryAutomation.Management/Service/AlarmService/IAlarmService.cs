using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Management.Service
{
    public interface IAlarmService
    {
        AlarmDialog AlarmOccur<T>(int ErrorCode) where T : class;
    }
}
