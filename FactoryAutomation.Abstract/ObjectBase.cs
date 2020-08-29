using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Abstract
{
    public abstract class ObjectBase : ObservableObject
    {
        public object LockObject 
        { 
            get 
            { 
                return m_LockObject;
            } 
        }
        object m_LockObject;
        public string Key 
        {
            get
            {
                return m_Key;
            }
            private set
            {
                Set<string>(ref m_Key, value);
            }
        }
        string m_Key;
        public string Text
        {
            get
            {
                return m_Text;
            }
            set
            {
                Set<string>(ref m_Text, value);
            }
        }
        string m_Text;
        public ObjectBase(string Key)
        {
            m_Key = Key;
            m_LockObject = new object();
        }
        public override string ToString()
        {
            if(string.IsNullOrEmpty(Text))
                return base.ToString();
            return Text;
        }
    }
}
