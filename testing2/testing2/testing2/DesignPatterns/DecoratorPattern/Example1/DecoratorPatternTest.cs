using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.DesignPatterns.DecoratorPattern
{
    public class DecoratorPatternTest
    {
        public static void TestDecorator()
        {
            Console.WriteLine("***Decorator pattern Demo***\n");
            ConcreteComponent cc = new ConcreteComponent();

            ConcreteDecoratorEx1 decorator1 = new ConcreteDecoratorEx1();
            decorator1.SetTheComponent(cc);
            decorator1.MakeHouse();

            ConcreteDecoratorEx2 decorator2 = new ConcreteDecoratorEx2();
            //Adding results from decorator1
            decorator2.SetTheComponent(decorator1);
            decorator2.MakeHouse();
        }
    }
}
