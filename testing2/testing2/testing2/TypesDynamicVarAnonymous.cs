using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{	
	public class TypesDynamicVarAnonymous
	{
		public static void DynamicObjectTest()
		{
			dynamic MyDynamic = new System.Dynamic.ExpandoObject();
			MyDynamic.A = "A";
			MyDynamic.B = "B";
			MyDynamic.C = "C";
			MyDynamic.Number = 12;
			MyDynamic.MyMethod = new Func<int>(() =>
			{
				return 55;
			});
			Console.WriteLine(MyDynamic.MyMethod());
		}

		public static void DynamicTypeOnClassesMethodsDemo()
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

		public static void DynamicTypeDemo()
		{
			dynamic test = new List<int>();
			dynamic test1 = new Single();
			dynamic test2 = new float();
		}

        // !! Data type of a variable declared using var will be assigned at COMPILE TIME
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

        #region Anonymous Types
        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of: {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}",
              obj.GetType().Name,
              obj.GetType().BaseType);
            Console.WriteLine("obj.ToString() == {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());
            Console.WriteLine();
        }

        public static void AnonymousTypeTest()
        {
            var steve = new { Name = "Steve", Description = "The anonymous object" };
            ReflectOverAnonymousType(steve);
        }

        public static void AnonymousTypesEqualityTest()
        {
            // Make 2 anonymous classes with identical name/value pairs.
            var firstCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
            var secondCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };

            // Are they considered equal when using Equals()?
            if (firstCar.Equals(secondCar))
                Console.WriteLine("Same anonymous object!");
            else
                Console.WriteLine("Not the same anonymous object!");

            // Are they considered equal when using ==?
            if (firstCar == secondCar)
                Console.WriteLine("Same anonymous object!");
            else
                Console.WriteLine("Not the same anonymous object!");

            // Are these objects the same underlying type?
            if (firstCar.GetType().Name == secondCar.GetType().Name)
                Console.WriteLine("We are both the same type!");
            else
                Console.WriteLine("We are different types!");

            // Show all the details.
            Console.WriteLine();
            ReflectOverAnonymousType(firstCar);
            ReflectOverAnonymousType(secondCar);
        }

        public static void AnonymousTypesWithinAnonymousTypes()
        {
            // Make an anonymous type that is composed of another.
            var purchaseItem = new
            {
                TimeBought = DateTime.Now,
                ItemBought = new { Color = "Red", Make = "Saab", CurrentSpeed = 55 },
                Price = 34.000
            };

            ReflectOverAnonymousType(purchaseItem);
        }
        #endregion
    }

	class ExampleClass
	{
		public ExampleClass() { }
		public ExampleClass(int v) { }

		public void ExampleMethod1(int i) { }

		public void ExampleMethod2(string str) { }
	}
}
