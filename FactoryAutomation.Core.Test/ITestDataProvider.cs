using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Core.Test
{
    public interface ITestDataProvider
    {
        IEnumerable<TestData> GetData();
    }
}
