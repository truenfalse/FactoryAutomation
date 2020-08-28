using FactoryAutomation.Core.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace FactoryAutomation.Core
{
    public class Container : IServiceLocator
    {
        public const string DefaultKey = "";

        Dictionary<Type, Type> m_InterfaceToServiceDictionary;
        Dictionary<Type, Dictionary<string, Delegate>> m_ServiceToFactoryDictionary;
        Dictionary<Type, Dictionary<string, object>> m_ServiceToInstanceDictionary;

        public Container()
        {
            m_InterfaceToServiceDictionary = new Dictionary<Type, Type>();
            m_ServiceToFactoryDictionary = new Dictionary<Type, Dictionary<string, Delegate>>();
            m_ServiceToInstanceDictionary = new Dictionary<Type, Dictionary<string, object>>();
        }

        public void Dispose()
        {
            foreach(Dictionary<string,object> dictionary in m_ServiceToInstanceDictionary.Values)
            {
                foreach(object instance in dictionary.Values)
                {
                    if(instance is IDisposable)
                    {
                        (instance as IDisposable).Dispose();
                    }
                }
            }
        }

        public void Register(Type TService, string Key = null)
        {
            string tempKey = Key;
            if(string.IsNullOrEmpty(tempKey))
            {
                tempKey = DefaultKey;
            }
            if(m_ServiceToFactoryDictionary.ContainsKey(TService))
            {
                if(m_ServiceToFactoryDictionary[TService].ContainsKey(tempKey))
                {
                    throw new Exception("Already Registered");
                }
                m_ServiceToFactoryDictionary[TService].Add(tempKey, null);
            }
            else
            {
                m_ServiceToFactoryDictionary.Add(TService, new Dictionary<string, Delegate>());
                m_ServiceToFactoryDictionary[TService].Add(tempKey, null);
            }
        }
        public void Register<TService>(string Key = null, Func<TService> Factory = null) where TService : class
        {
            string tempKey = Key;
            if (string.IsNullOrEmpty(tempKey))
            {
                tempKey = DefaultKey;
            }

            if (m_ServiceToFactoryDictionary.ContainsKey(typeof(TService)))
            {
                if (m_ServiceToFactoryDictionary[typeof(TService)].ContainsKey(tempKey))
                {
                    throw new Exception("Already Registered");
                }
                m_ServiceToFactoryDictionary[typeof(TService)].Add(tempKey, Factory);
            }
            else
            {
                m_ServiceToFactoryDictionary.Add(typeof(TService), new Dictionary<string, Delegate>());
                m_ServiceToFactoryDictionary[typeof(TService)].Add(tempKey, Factory);
            }
        }
        public void Register<TInterface, TService>(string Key = null, Func<TService> Factory = null) where TInterface : class
            where TService : class, TInterface
        {
            string tempKey = Key;
            if (string.IsNullOrEmpty(tempKey))
            {
                tempKey = DefaultKey;
            }

            if(!m_InterfaceToServiceDictionary.ContainsKey(typeof(TInterface)))
            {
                m_InterfaceToServiceDictionary.Add(typeof(TInterface), typeof(TService));
            }

            if (m_ServiceToFactoryDictionary.ContainsKey(typeof(TService)))
            {
                if (m_ServiceToFactoryDictionary[typeof(TService)].ContainsKey(tempKey))
                {
                    throw new Exception("Already Registered");
                }
                m_ServiceToFactoryDictionary[typeof(TService)].Add(tempKey, Factory);
            }
            else
            {
                m_ServiceToFactoryDictionary.Add(typeof(TService), new Dictionary<string, Delegate>());
                m_ServiceToFactoryDictionary[typeof(TService)].Add(tempKey, Factory);
            }
        }

        public object Resolve(Type TService, string Key = null)
        {
            if(TService.IsInterface == true)
            {
                if (m_InterfaceToServiceDictionary.ContainsKey(TService))
                    return Resolve(m_InterfaceToServiceDictionary[TService],Key);
            }

            string tempKey = Key;
            if (string.IsNullOrEmpty(tempKey))
            {
                tempKey = DefaultKey;
            }

            if (m_ServiceToInstanceDictionary.ContainsKey(TService))
            {
                if (m_ServiceToInstanceDictionary[TService].ContainsKey(tempKey)) // Key에 맞는 Instance가 있을경우
                    return m_ServiceToInstanceDictionary[TService][tempKey];
                else // Key에 맞는 인스턴스가 없는경우
                {
                    if (m_ServiceToFactoryDictionary.ContainsKey(TService))
                    {
                        if (m_ServiceToFactoryDictionary[TService].ContainsKey(tempKey))
                        {
                            object Instance = m_ServiceToFactoryDictionary[TService][tempKey].DynamicInvoke();
                            m_ServiceToInstanceDictionary[TService].Add(tempKey, Instance);
                        }
                        else
                        {
                            throw new Exception("No Registered TService");
                        }
                    }
                    else
                    {
                        throw new Exception("No Registered TService");
                    }
                }
            }
            else
            {
                if (m_ServiceToFactoryDictionary.ContainsKey(TService))
                {
                    if (m_ServiceToFactoryDictionary[TService].ContainsKey(tempKey))
                    {
                        object Instance = CreateInstance(TService);
                        m_ServiceToInstanceDictionary.Add(TService, new Dictionary<string, object>());
                        m_ServiceToInstanceDictionary[TService].Add(tempKey, Instance);
                    }
                    else
                    {
                        throw new Exception("No Registered TService");
                    }
                }
                else
                {
                    throw new Exception("No Registered TService");
                }
            }
            return m_ServiceToInstanceDictionary[TService][tempKey];
        }

        public TService Resolve<TService>(string Key = null) where TService : class
        {
            if (typeof(TService).IsInterface == true)
            {
                if (m_InterfaceToServiceDictionary.ContainsKey(typeof(TService)))
                    return Resolve(m_InterfaceToServiceDictionary[typeof(TService)], Key) as TService;
            }

            string tempKey = Key;
            if (string.IsNullOrEmpty(tempKey))
            {
                tempKey = DefaultKey;
            }

            if (m_ServiceToInstanceDictionary.ContainsKey(typeof(TService)))
            {
                if (m_ServiceToInstanceDictionary[typeof(TService)].ContainsKey(tempKey)) // Key에 맞는 Instance가 있을경우
                    return m_ServiceToInstanceDictionary[typeof(TService)][tempKey] as TService;
                else // Key에 맞는 인스턴스가 없는경우
                {
                    if(m_ServiceToFactoryDictionary.ContainsKey(typeof(TService)))
                    {
                        if(m_ServiceToFactoryDictionary[typeof(TService)].ContainsKey(tempKey))
                        {
                            object Instance = m_ServiceToFactoryDictionary[typeof(TService)][tempKey].DynamicInvoke();
                            m_ServiceToInstanceDictionary[typeof(TService)].Add(tempKey, Instance);
                        }
                        else
                        {
                            throw new Exception("No Registered TService");
                        }
                    }
                    else
                    {
                        throw new Exception("No Registered TService");
                    }
                }
            }
            else
            {
                if (m_ServiceToFactoryDictionary.ContainsKey(typeof(TService)))
                {
                    if (m_ServiceToFactoryDictionary[typeof(TService)].ContainsKey(tempKey))
                    {
                        object Instance = CreateInstance(typeof(TService));
                        m_ServiceToInstanceDictionary.Add(typeof(TService), new Dictionary<string, object>());
                        m_ServiceToInstanceDictionary[typeof(TService)].Add(tempKey, Instance);
                    }
                    else
                    {
                        throw new Exception("No Registered TService");
                    }
                }
                else
                {
                    throw new Exception("No Registered TService");
                }
            }
            return m_ServiceToInstanceDictionary[typeof(TService)][tempKey] as TService;
        }
        private object CreateInstance(Type TService)
        {
            ConstructorInfo[] ctorInfos = TService.GetConstructors();
            ConstructorInfo InjectionCtor = null;
            for(int i = 0; i < ctorInfos.Length; i++)
            {
                Attribute attr = ctorInfos[i].GetCustomAttribute(typeof(InjectionConstructorAttribute));
                if (attr != null)
                {
                    InjectionCtor = ctorInfos[i];
                    break;
                }
            }
            if (InjectionCtor == null)
                return Activator.CreateInstance(TService);

            ParameterInfo[] ParameterInfos = InjectionCtor.GetParameters();
            object[] Parameters = new object[ParameterInfos.Length];
            for(int i = 0; i < ParameterInfos.Length; i++)
            {
                InjectionParameterAttribute attr = ParameterInfos[i].GetCustomAttribute(typeof(InjectionParameterAttribute)) as InjectionParameterAttribute;
                if(attr != null)
                {
                    Parameters[ParameterInfos[i].Position] = Resolve(ParameterInfos[i].ParameterType, attr.Key);
                }
            }
            return InjectionCtor.Invoke(Parameters);
        }
    }
}
