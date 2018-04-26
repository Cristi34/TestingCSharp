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
		private double radius;
		public Circle(double radius)
		{
			this.radius = radius;
		}

		public double Calculate(Func<double, double> op)
		{
			return op(this.radius);
		}
	}

	public class CircleSOLID
	{
		//public double Area(double radius)
		//{
		//	return Math.PI * radius * radius;
		//}

		public static void TestArea()
		{
			Circle c = new Circle(5);
			Console.WriteLine(c.Calculate(x => Math.PI * x * x));
		}
	}
}
