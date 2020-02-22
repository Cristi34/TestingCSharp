using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.DesignPatterns.BuilderPattern
{
    public class BuilderPatternTest
    {
        public static void TestBuilderPattern()
        {
            Console.WriteLine("***Builder Pattern Demo***");
            Director director = new Director();

            IBuilder b1 = new Car("Ford");
            IBuilder b2 = new MotorCycle("Honda");

            // Making Car
            director.Construct(b1);
            Product p1 = b1.GetVehicle();
            p1.Show();

            //Making MotorCycle
            director.Construct(b2);
            Product p2 = b2.GetVehicle();
            p2.Show();
        }
    }
}
