using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Abstract.Interface
{
    public interface IParams : ICloneable
    {
        object SelectedObject { get; set; }
    }
}
