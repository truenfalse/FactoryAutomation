using FactoryAutomation.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FactoryAutomation.Abstract
{
    public abstract class ObservableObject : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                m_PropertyChangedEventManager.Add(value);
            }
            remove
            {
                m_PropertyChangedEventManager.Remove(value);
            }
        }
        EventManager<PropertyChangedEventArgs> m_PropertyChangedEventManager;
        public ObservableObject()
        {
            m_PropertyChangedEventManager = new EventManager<PropertyChangedEventArgs>();
        }
        virtual protected void Set<T>(ref T _Field, T _Value, bool _ForceOnPropertyChanged = false, [CallerMemberName] string PropName = null)
        {
            if (!(_Field is null))
            {
                if (_Field.Equals(_Value))
                {
                    if (_ForceOnPropertyChanged)
                        OnPropertyChanged(PropName);
                    return;
                }
            }
            _Field = _Value;
            OnPropertyChanged(PropName);
        }
        protected void OnPropertyChanged([CallerMemberName]string PropName=null)
        {
            m_PropertyChangedEventManager.Publish(this, new PropertyChangedEventArgs(PropName));
        }
        virtual public void Dispose()
        {
            m_PropertyChangedEventManager.Clear();
            m_PropertyChangedEventManager = null;
        }
    }
}
