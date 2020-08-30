using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FactoryAutomation.WPF
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        Action<object> m_Execute;
        Predicate<object> m_CanExecute;
        private CommandBase windowCloseCommand;

        public CommandBase(Action<object> _Execute, Predicate<object> _CanExecute = null)
        {
            m_Execute = _Execute;
            m_CanExecute = _CanExecute;
        }

        public CommandBase(CommandBase windowCloseCommand)
        {
            this.windowCloseCommand = windowCloseCommand;
        }

        public bool CanExecute(object parameter)
        {
            if (m_CanExecute == null)
                return true;
            return m_CanExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            m_Execute?.Invoke(parameter);
        }
    }
}
