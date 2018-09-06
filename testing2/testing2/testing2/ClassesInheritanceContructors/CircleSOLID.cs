using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.ClassesInheritanceContructors
{
	// calculate the area without modifying Circle class
	public sealed class Circle
	{
		private double Radius;
        public double Diameter => Radius * 2;
		public Circle(double radius)
		{
			this.Radius = radius;
		}

		public double Calculate(Func<double, double> op)
		{
			return op(this.Radius);
		}
	}

	public class CircleSOLID
	{
        //public static double CalculateArea(double radius)
        //{
        //    return Math.PI * radius * radius;
        //}
        //private delegate double CalculateAreaDelegate(double r);

		public static void TestArea()
		{
			Circle c = new Circle(5);
			Console.WriteLine(c.Calculate(x => Math.PI * x * x));                        
        }
	}
}
