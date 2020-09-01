using FactoryAutomation.Abstract;
using System;

namespace FactoryAutomation.Management
{
    public class AppManager : ObservableObject
    {
        private string m_Title;
        private RunState m_RunState;
        private RunMode m_RunMode;
        public string Title 
        {
            get
            {
                return m_Title;
            }
            set
            {
                Set<string>(ref m_Title, value);
            }
        }
        public RunState RunState
        {
            get
            {
                return m_RunState;
            }
            set
            {
                Set<RunState>(ref m_RunState, value);
                OnPropertyChanged(nameof(IsAuto));
            }
        }
        public bool IsAuto
        {
            get
            {
                if (RunState == RunState.Wait)
                    return false;
                else
                    return true;
            }
            set
            {
                if (value == false)
                    RunState = RunState.Wait;
                else
                    RunState = RunState.Running;
            }
        }
        public RunMode RunMode
        {
            get
            {
                return m_RunMode;
            }
            set
            {
                Set<RunMode>(ref m_RunMode, value);
            }
        }
        public AppManager()
        {

        }
    }
}
