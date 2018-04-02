using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{	
	public class DynamicAndVarTypesTest
	{
		public static void DynamicTypeDemo()
		{
			ExampleClass ec = new ExampleClass();
			// The following call to exampleMethod1 causes a compiler error 
			// if exampleMethod1 has only one parameter. Uncomment the line
			// to see the error.
			//ec.exampleMethod1(10, 4);

			dynamic dynamic_ec = new ExampleClass();
			// The following line is not identified as an error by the
			// compiler, but it causes a run-time exception.
			dynamic_ec.exampleMethod1(10, 4);

			// The following calls also do not cause compiler errors, whether 
			// appropriate methods exist or not.
			dynamic_ec.someMethod("some argument", 7, null);
			dynamic_ec.nonexistentMethod();
		}

		public static void VarDemo()
		{
			// Example #1: var is optional because
			// the select clause specifies a string
			string[] words = { "apple", "strawberry", "grape", "peach", "banana" };
			var wordQuery = from word in words
							where word[0] == 'g'
							select word;

			// Because each element in the sequence is a string, 
			// not an anonymous type, var is optional here also.
			foreach (string s in wordQuery)
			{
				Console.WriteLine(s);
			}

			// Example #2: var is required because
			// the select clause specifies an anonymous type
			//var custQuery = from cust in customers
			//				where cust.City == "Phoenix"
			//				select new { cust.Name, cust.Phone };

			// var must be used because each item 
			// in the sequence is an anonymous type
			//foreach (var item in custQuery)
			//{
			//	Console.WriteLine("Name={0}, Phone={1}", item.Name, item.Phone);
			//}
		}
	}

	class ExampleClass
	{
		public ExampleClass() { }
		public ExampleClass(int v) { }

		public void exampleMethod1(int i) { }

		public void exampleMethod2(string str) { }
	}
}
