using FactoryAutomation.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Management.Service
{
    public class AlarmDescriptor : ObservableObject
    {
        public AlarmLevel Level { get; set; }
        public Type ObjectType { get; set; }
        public string Key { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
