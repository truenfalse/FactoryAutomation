using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FactoryAutomation.Abstract
{
    public abstract class ObservableObject : INotifyPropertyChanged, IDisposable
    {
        public ObservableObject()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        virtual public void Dispose()
        {

        }
    }
}
