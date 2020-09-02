using FactoryAutomation.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace FactoryAutomation.Management.Service
{
    public class ModuleFactory
    {
        private ObservableCollection<ModuleBase> m_ModuleInstances;
        private ObservableCollection<Type> m_RegisterTypes;
        private IModuleFinder m_ModuleFinder;
        public ObservableCollection<Type> RegisterTypes
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
        public ObservableCollection<ModuleBase> ModuleInstances
        {
            get
            {
                return m_ModuleInstances;
            }
        }
        public ModuleFactory(IModuleFinder _ModuleFinder)
        {
            m_ModuleFinder = _ModuleFinder;
            RegisterTypes = new ObservableCollection<Type>(_ModuleFinder.FindModuleTypes()); ;
            m_ModuleInstances = new ObservableCollection<ModuleBase>();
        }
        public ModuleBase CreateInstance(Type T, string Key)
        {
            object module = Activator.CreateInstance(T, new object[1] { Key });
            ModuleInstances.Add(module as ModuleBase);
            return module as ModuleBase;
        }
        public T CreateInstance<T>(string Key) where T : ModuleBase
        {
            object module = Activator.CreateInstance(typeof(T), new object[1] { Key });
            ModuleInstances.Add(module as ModuleBase);
            return module as T;
        }
    }
}
