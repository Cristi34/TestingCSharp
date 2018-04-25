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

		static void TestDeriv()
		{
			BaseAbstractClass baseAbstractDerived = new Derived();
			baseAbstractDerived.F1();
			baseAbstractDerived.F2();
			baseAbstractDerived.F3();
			baseAbstractDerived.AbstractMe();
			//b.DerivedClassMethod();
		}

		/*
			Contains only static members.
			Cannot be instantiated.
			Is sealed.
			Cannot contain Instance Constructors.
		*/
		public static class StaticTest
		{
			public static void TestMethod()
			{
				Console.WriteLine("test method from static class");
			}
		}

		abstract class BaseAbstractClass
		{
			public void F1() { Console.WriteLine("base f1"); }
			public virtual void F2() { Console.WriteLine("base f2"); }
			public virtual void F3() { Console.WriteLine("base f3"); }
			public abstract void AbstractMe();
		}
		class Derived : BaseAbstractClass
		{
			new public void F1() { Console.WriteLine("derived f1"); }
			public override void F2() { Console.WriteLine("derived f2"); }
			public new void F3() { Console.WriteLine("derived f3"); }
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

			public List<int> TestList { get; set; }
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
			public virtual void A()
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
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

		}
		public class DerivedClass2 : BaseClass2
		{
			public new void A()
			{
				Console.WriteLine("a from derived class");
			}
			//public override void a()
			//{
			//    Console.WriteLine("a overriden in derived class");
			//}
			public void AFromBase()
			{
				base.A();
			}
			public void DerivedClassMethod()
			{
				Console.WriteLine("derived class method");
			}
		}
	}
}
