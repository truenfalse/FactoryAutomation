using FactoryAutomation.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Core
{
    public static class ServiceLocator
    {
        static public IServiceLocator Current
        {
            get
            {
                return m_Current;
            }
        }
        static public void Initialize(Func<IServiceLocator> ServiceLocator)
        {
            if (m_Current != null)
                m_Current.Dispose();
            m_Current = ServiceLocator.Invoke();
        }
        static IServiceLocator m_Current;
    }
}
