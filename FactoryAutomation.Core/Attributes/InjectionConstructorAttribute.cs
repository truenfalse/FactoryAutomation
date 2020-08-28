using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Core
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class InjectionConstructorAttribute : Attribute
    {

    }
}
