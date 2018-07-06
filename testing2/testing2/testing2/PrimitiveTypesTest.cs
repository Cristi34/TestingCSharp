using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingCSharp.DesignPatterns.PaymentFactory;

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
			x.GetType();
		}

		enum Types : byte
		{
			type1 = 1,
			type2 = 2,
			
			// values 256 is not byte so this gives error
			//type3 = 256
		}

		// for test weird
		public static void ForTest()
		{
			float f;
			for (f = 0.1f; f <= 0.5; f += 1)
				Console.WriteLine(++f);
		}

		public static decimal Fun(int i, Single j, double k)
		{
			return 5; 
		}
		public static void DataConversion()
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

		public static void InterestingResult()
		{
			int x = 1;
			float y = 2.4f;
			short z = 1;
			Console.WriteLine((float)x + y * z - (x += (short)y));
			Console.ReadLine();
		}
		public static void Calcultest()
		{
			int a = 12;
			float b = 6.2f;
			int c;
			//c = a / Convert.ToInt32(b) + a * Convert.ToInt32(b);
			// works but different result because of approximation
			c = Convert.ToInt32(a / b) + Convert.ToInt32(a * b);
			Console.WriteLine(c);
		}

		public static void RefTest()
		{
			int age1 = 20;
			ChangeInt(ref age1);
			Console.WriteLine("Effective parameter " + age1);
		}
		public static void ChangeInt(ref int age2)
		{
			age2 = 30;
			Console.WriteLine("Formal parameter " + age2);
		}

		public static void CielFloor()
		{
			double x = 4.56, y = 4.15;
			Console.WriteLine("for Ceiling(" + x + ") = " + Math.Ceiling(x));
			Console.WriteLine("for Ceiling(" + y + ") = " + Math.Ceiling(y));
			Console.WriteLine("for Floor(" + x + ") = " + Math.Floor(x));
			Console.WriteLine("for Floor(" + y + ") = " + Math.Floor(y));
		}

		public void FloatTest()
		{
			int i = 3, j = 4;
			float f1 = (float)i / j;
			Console.Write(f1);
			Console.ReadLine();
		}

        // structs don't support inheritance from class type
        // but they can implement an interface
        public struct Book : IEnumerable
		{
			public String name;
			public int pages;
			public Single price;
			public Product product;

			// for a struct you can only define a constructor with parameters AND MUST include all struct fields
			public Book(string name, int pages, Single price, Product product)
			{
				this.name = name;
				this.pages = pages;
				this.price = price;
				this.product = product;
			}

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
        		
		public static void StructTest()
		{
			Book b = new Book
			{
				name = "Carl",
				pages = 34,
				price = 5.4f,
				product = new Product
				{
					Name = "HayHui",
					Price = 59
				} 
			};
			Book c = new Book
			{
				name = "Carl",
				pages = 34,
				price = 5.4f
			};
			Book a = new Book();
			a.name = "Alabala";
			Book d = new Book
			{
				name = "pl"
			};

			// returns true if all fields are equal
			Console.WriteLine(b.Equals(c));
		}
	}
}
