using FactoryAutomation.Abstract.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Abstract
{
    public abstract class DeviceBase : ObjectBase
    {
        public int ErrorCode 
        {
            get
            {
                return m_ErrorCode;
            }
            protected set
            {
                Set<int>(ref m_ErrorCode, value);
            }
        }
        int m_ErrorCode;
        public IParams DeviceParams 
        {
            get
            {
                return m_DeviceParams;
            }
            set
            {
                Set<IParams>(ref m_DeviceParams, value);
            }
        }
        IParams m_DeviceParams;
        public string Message 
        {
            get
            {
                return m_Message;
            }
            protected set
            {
                Set<string>(ref m_Message, value);
            }
        }
        string m_Message;
        public DeviceBase(string Key) : base(Key)
        {

        }
        abstract public void Reset();
    }
}
