using FactoryAutomation.WPF;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Designer.ViewModels
{
    public class MainVIewModel : ViewModelBase
    {
        bool IsPressedA;
        public CommandBase ACommand { get; set; }
        public CommandBase BCommand { get; set; }
        public MainVIewModel()
        {
            ACommand = new CommandBase(AAction, APredicate);
            BCommand = new CommandBase(BAction, BPredicate);
        }

        private bool BPredicate(object obj)
        {
            return !IsPressedA;
        }

        private void BAction(object obj)
        {
            
        }

        private bool APredicate(object obj)
        {
            return true;
        }

        private void AAction(object obj)
        {
            if (IsPressedA == false)
                IsPressedA = true;
            else
                IsPressedA = false;
        }
    }
}
