using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Core.Interface
{
    public interface IServiceLocator : IDisposable
    {
        object Resolve(Type TService, string Key = null);
        TService Resolve<TService>(string Key = null) where TService : class;
        void Register(Type TService, string Key = null);
        void Register<TInterface, TService>(string Key = null, Func<TService> Factory = null) where TInterface : class
        where TService : class, TInterface;
        void Register<TService>(string Key = null, Func<TService> Factory = null) where TService : class;
    }
}
