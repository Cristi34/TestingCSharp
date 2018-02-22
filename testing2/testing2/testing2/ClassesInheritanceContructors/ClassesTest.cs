using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.ClassesInheritanceContructors
{
	public class ClassesTest
	{
		public static void LiskovPrinciple()
		{
			Car myLamborghini = new Car();
			myLamborghini.DriveTo("Los Santos");

			Vehicle myVehicle = new Car();

			Car myToyota = new Toyota();
			myToyota.DriveTo("Pitesti");
		}

		static void testDeriv()
		{
			BaseClass b = new Derived();
			b.f1();
			b.f2();
			b.f3();
			b.AbstractMe();
			//b.DerivedClassMethod();
		}

		abstract class BaseClass
		{
			public void f1() { Console.WriteLine("base f1"); }
			public virtual void f2() { Console.WriteLine("base f2"); }
			public virtual void f3() { Console.WriteLine("base f3"); }
			public abstract void AbstractMe();
		}
		class Derived : BaseClass
		{
			new public void f1() { Console.WriteLine("derived f1"); }
			public override void f2() { Console.WriteLine("derived f2"); }
			public new void f3() { Console.WriteLine("derived f3"); }
			public override void AbstractMe()
			{
				Console.WriteLine("implemented abstract method from Derived class");
			}
			public void DerivedClassMethod()
			{
				Console.WriteLine("dervied class method");
			}
			~Derived()
			{
				Console.WriteLine("Dervied destructor call");
			}
		}

		public class BaseClassSample
		{
			public int x = 100;
			public int y = 150;
			public void TestMethod()
			{
				Console.WriteLine("base class method");
			}
		}
		public class DerivedClass : BaseClassSample
		{
			new public static int x = 1000;
			int w, q;
			void TestBase()
			{
				w = base.y;
				q = base.x;
			}
		}

		public class Pet
		{
			public string Name { get; set; }
			public int Age { get; set; }

			public List<int> testList { get; set; }
		}

		public class BaseClass2
		{
			public int x;
			string name;

			public BaseClass2()
			{
				Console.WriteLine("base class default constructor");
			}
			public BaseClass2(string name)
			{
				Console.WriteLine("base class constructor with parameter name = " + name);
				this.name = name;
			}
			public virtual void a()
			{
				Console.WriteLine("a from base class");
			}
			public override bool Equals(object obj)
			{
				var converted = obj as BaseClass2;
				if (converted.x == this.x)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			public override string ToString()
			{
				return this.name;
			}

		}
		public class DerivedClass2 : BaseClass2
		{
			new public void a()
			{
				Console.WriteLine("a from derived class");
			}
			//public override void a()
			//{
			//    Console.WriteLine("a overriden in derived class");
			//}
			public void aFromBase()
			{
				base.a();
			}
			public void DerivedClassMethod()
			{
				Console.WriteLine("derived class method");
			}
		}
	}
}
