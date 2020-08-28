using System;

namespace FactoryAutomation.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is FactoryAutomation Core Test Program");

            ServiceLocator.Initialize(new Container());
        }
    }
}
