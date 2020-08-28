using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FactoryAutomation.Core
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class InjectionParameterAttribute : Attribute
    {
        public string Key 
        {
            get
            {
                return m_Key;
            }
            set
            {
                m_Key = value;
            }
        }
        string m_Key;
        public InjectionParameterAttribute()
        {

        }
        public InjectionParameterAttribute(string Key)
        {
            m_Key = Key;
        }
    }
}
