using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Core.Test
{
    public class TestDataConstructorProvider : ITestDataProvider
    {
        public TestDataConstructorProvider()
        {

        }

        public IEnumerable<TestData> GetData()
        {
            return new TestData[]
            {
                new TestData(),
            };
        }
    }
}
