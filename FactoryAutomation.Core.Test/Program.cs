using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryAutomation.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is FactoryAutomation Core Test Program");

            ServiceLocator.Initialize(()=>
            {
                return new Container();
            });

            ServiceLocator.Current.Register<ITestDataProvider, TestDataConstructorProvider>("TestDataProvider");
            ServiceLocator.Current.Register<TestDataCollection>("TestDataCollection");

            Console.WriteLine("Interface To Service Register Test Completed");

            Console.WriteLine("Interface To Service Resolve Test Start");
            ITestDataProvider dataProvider = ServiceLocator.Current.Resolve<ITestDataProvider>("TestDataProvider");
            TestData[] dataArray = dataProvider.GetData().ToArray();
            for(int i = 0; i < dataArray.Length; i++)
            {
                Console.WriteLine("TestData{0} : TestProperty = {1}", i, dataArray[i].TestProperty);
            }
            Console.WriteLine("Interface To Service Resolve Test Completed");

            Console.WriteLine("Injection Constructor Test Start");
            TestDataCollection TestDataCollection = ServiceLocator.Current.Resolve<TestDataCollection>("TestDataCollection");
            for (int i = 0; i < TestDataCollection.Count; i++)
            {
                Console.WriteLine("TestData{0} : TestProperty = {1}", i, dataArray[i].TestProperty);
            }
            Console.WriteLine("Injection Constructor Test Completed");
        }
    }
}
