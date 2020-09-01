using FactoryAutomation.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FactoryAutomation.Management.Service
{
    public interface IDeviceFinder
    {
        ObservableCollection<Type> FindDeviceTypes();
        void Refresh();
    }
}
