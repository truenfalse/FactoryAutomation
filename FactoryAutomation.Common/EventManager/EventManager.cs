using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Common
{
    public class EventManager<T>
    {
        List<EventHandler<T>> m_ListEventHandler;
        public EventManager()
        {
            m_ListEventHandler = new List<EventHandler<T>>();
        }
        public void Add(EventHandler<T> Handler)
        {
            if (m_ListEventHandler.Exists(x => x.Target == Handler.Target && x.Method == Handler.Method))
                throw new ArgumentException("Handler already exist");
            m_ListEventHandler.Add(Handler);
        }
        public void Remove(EventHandler<T> Handler)
        {
            m_ListEventHandler.Remove(Handler);
        }
        public void Add(Delegate invoker)
        {
            object evt = Delegate.CreateDelegate(typeof(EventHandler<T>), invoker.Target, invoker.Method);
            if (evt is EventHandler<T>)
            {
                Add(evt as EventHandler<T>);
            }
        }
        public void Remove(Delegate invoker)
        {
            object evt = Delegate.CreateDelegate(typeof(EventHandler<T>), invoker.Target, invoker.Method);
            if (evt is EventHandler<T>)
            {
                Remove(evt as EventHandler<T>);
            }
        }
        public void Clear()
        {
            m_ListEventHandler.Clear();
        }
        public void Publish(object sender, T EventArgs)
        {
            foreach (EventHandler<T> evt in m_ListEventHandler)
            {
                evt.Invoke(sender, EventArgs);
            }
        }
    }
}
