using FactoryAutomation.WPF;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Management.Service
{
    public class AlarmDescriptorViewModel : ViewModelBase
    {
        private AlarmDescriptor m_AlarmDescriptor;

        public AlarmDescriptor Alarm
        {
            get
            {
                return m_AlarmDescriptor;
            }
            set
            {
                Set<AlarmDescriptor>(ref m_AlarmDescriptor, value);
            }
        }
        public AlarmDescriptorViewModel(AlarmDescriptor Descriptor)
        {
            m_AlarmDescriptor = Descriptor;
        }
    }
}
