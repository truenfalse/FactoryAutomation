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
                new TestData(){TestProperty = 0 },
                new TestData(){TestProperty = 1 },
                new TestData(){TestProperty = 2 },
                new TestData(){TestProperty = 3 },
                new TestData(){TestProperty = 4 },
                new TestData(){TestProperty = 5 },
                new TestData(){TestProperty = 6 },
                new TestData(){TestProperty = 7 },
                new TestData(){TestProperty = 8 },
                new TestData(){TestProperty = 9 },
            };
        }
    }
}
