using FactoryAutomation.Abstract;
using FactoryAutomation.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
namespace FactoryAutomation.Management.Service
{
    public class DeviceFactory : ObservableObject
    {
        private ObservableCollection<Type> m_RegisterTypes;
        private IDeviceFinder m_DeviceFinder;
        private ObservableCollection<DeviceBase> m_DeviceInstances;
        public ObservableCollection<DeviceBase> DeviceInstances
        {
            get
            {
                return m_DeviceInstances;
            }
        }
        public ObservableCollection<Type> RegisteredType
        {
            get
            {
                return m_RegisterTypes;
            }
            set
            {
                m_RegisterTypes = value;
            }
        }
        [InjectionConstructor]
        public DeviceFactory([InjectionParameter]IDeviceFinder DeviceFinder)
        {
            m_DeviceFinder = DeviceFinder;
            RegisteredType = new ObservableCollection<Type>(DeviceFinder.FindDeviceTypes());
            m_DeviceInstances = new ObservableCollection<DeviceBase>();
        }
        public DeviceBase CreateInstance(Type T, string Key)
        {
            object device = Activator.CreateInstance(T, new object[1] { Key });
            DeviceInstances.Add(device as DeviceBase);
            return device as DeviceBase;
        }
        public T CreateInstance<T>(string Key) where T : DeviceBase
        {
            object device = Activator.CreateInstance(typeof(T), new object[1] { Key });
            m_DeviceInstances.Add(device as DeviceBase);
            return device as T;
        }
    }
}
