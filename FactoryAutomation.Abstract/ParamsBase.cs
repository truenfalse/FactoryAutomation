using FactoryAutomation.Abstract.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace FactoryAutomation.Abstract
{
    // Don't create Field without Property
    public class ParamsBase : ObservableObject, IParams
    {
        [Browsable(false)]
        public object SelectedObject { get; set; }
        public ParamsBase()
        {

        }
        public ParamsBase(object SelectedObject)
        {
            this.SelectedObject = SelectedObject;
        }
        public object Clone()
        {
            PropertyInfo[] PropInfoArray = this.GetType().GetProperties();
            object cloneObj = Activator.CreateInstance(this.GetType());
            foreach(PropertyInfo propInfo in PropInfoArray)
            {
                object val = propInfo.GetValue(this);
                propInfo.SetValue(cloneObj, val);
            }
            return cloneObj;
        }
    }
}
