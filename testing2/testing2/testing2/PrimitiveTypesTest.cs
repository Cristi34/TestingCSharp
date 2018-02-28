using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
	// Primitive types, structs, enums 
	public class PrimitiveTypesTest
	{
		//enum test
		enum Days { Mon, Tue, Wed, Thu, Fri, Sat, Sun }
		public static void EnumTest()
		{
			// casting needed
			int x = (int)Days.Mon;
		}

		// for test weird
		static void ForTest()
		{
			float f;
			for (f = 0.1f; f <= 0.5; f += 1)
				Console.WriteLine(++f);
		}

		static decimal Fun(int i, Single j, double k)
		{
			return 5;
		}
		static void DataConversion()
		{
			int a = 22;
			long b = 44;
			double c = 1.406;
			b = a;
			c = a;
			a = (int)b;
			b = (long)c;
			// not like this:
			//a = b;
			//b = c;
		}

		static void InterestingResult()
		{
			int x = 1;
			float y = 2.4f;
			short z = 1;
			Console.WriteLine((float)x + y * z - (x += (short)y));
			Console.ReadLine();
		}
		static void Calcultest()
		{
			int a = 12;
			float b = 6.2f;
			int c;
			//c = a / Convert.ToInt32(b) + a * Convert.ToInt32(b);
			// works but differnt result because of approximation
			c = Convert.ToInt32(a / b) + Convert.ToInt32(a * b);
			Console.WriteLine(c);
		}

		static void RefTest()
		{
			int age1 = 20;
			ChangeInt(ref age1);
			Console.WriteLine("Effective parameter " + age1);
		}
		static void ChangeInt(ref int age2)
		{
			age2 = 30;
			Console.WriteLine("Formal parameter " + age2);
		}

		static void CielFloor()
		{
			double x = 4.56, y = 4.15;
			Console.WriteLine("for Ceiling(" + x + ") = " + Math.Ceiling(x));
			Console.WriteLine("for Ceiling(" + y + ") = " + Math.Ceiling(y));
			Console.WriteLine("for Floor(" + x + ") = " + Math.Floor(x));
			Console.WriteLine("for Floor(" + y + ") = " + Math.Floor(y));
		}

		void FloatTest()
		{
			int i = 3, j = 4;
			float f1 = (float)i / j;
			Console.Write(f1);
			Console.ReadLine();
		}

		struct Book
		{
			private String name;
			private int pages;
			private Single price;
		}
		void StructTest()
		{
			Book b = new Book();
		}
	}
}
