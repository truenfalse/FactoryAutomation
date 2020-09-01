using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Management.Service
{
    public interface IAlarmProvider
    {
        Dictionary<Tuple<Type,int>, AlarmDescriptor> GetAlarmDictionary();
    }
}
