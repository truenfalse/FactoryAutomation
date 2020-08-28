using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryAutomation.Core.Test
{
    public class TestDataCollection : List<TestData>
    {
        ITestDataProvider m_DataProvider;
        [InjectionConstructor]
        public TestDataCollection([InjectionParameter("TestDataProvider")]ITestDataProvider Provider)
        {
            m_DataProvider = Provider;
            AddRange(m_DataProvider.GetData());
        }
    }
}
