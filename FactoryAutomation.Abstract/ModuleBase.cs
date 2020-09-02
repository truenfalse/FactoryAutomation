using FactoryAutomation.Abstract.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Abstract
{
    public class ModuleBase : ObjectBase, IModule
    {
        private int m_ErrorCode;
        private string m_Message;
        private IParams m_InputParams;
        private IParams m_OutputParams;

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
        public IParams InputParams 
        {
            get
            {
                return m_InputParams;
            }
            protected set
            {
                Set<IParams>(ref m_InputParams, value);
            }
        }
        public IParams OutputParams
        {
            get
            {
                return m_OutputParams.Clone() as IParams;
            }
            set
            {
                Set<IParams>(ref m_OutputParams, value);
            }
        }
        public ModuleBase(string Key) : base(Key)
        {

        }
    }
}
