using FactoryAutomation.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Management.Service
{
    public class AlarmService : IAlarmService
    {
        Dictionary<Tuple<Type,int>, AlarmDescriptor> m_AlarmDictionary;
        [InjectionConstructor]
        public AlarmService([InjectionParameter]IAlarmProvider Provider)
        {
            m_AlarmDictionary = Provider.GetAlarmDictionary();
        }
        public AlarmDialog AlarmOccur<T>(int ErrorCode) where T : class
        {
            if (ErrorCode == 0) // Success
                return null;

            Tuple<Type, int> Key = new Tuple<Type, int>(typeof(T), ErrorCode);
            if(m_AlarmDictionary.ContainsKey(Key))
            {
                AlarmDialog dialog = new AlarmDialog();
                AlarmDescriptorViewModel viewmodel = new AlarmDescriptorViewModel(m_AlarmDictionary[Key]);
                dialog.DataContext = viewmodel;
                return dialog;
            }

            throw new Exception("No Registered Alarm Descriptor");
        }
    }
}
