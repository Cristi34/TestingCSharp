using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
	public class EnumerablesTest
	{
		static void TestYield()
		{
			foreach (var i in Integers())
			{
				Console.WriteLine(i);
			}
		}

		public static IEnumerable Integers()
		{
			List<int> list = new List<int>() { 1, 2, 3, 4, 5, 123, 456, 1234 };
			yield return list;
		}

		public static void UpperBoundTest()
		{
			int[,] intMyArr = { { 7, 1, 3 }, { 2, 9, 6 } };
			Console.WriteLine(intMyArr.GetUpperBound(1));
			Console.WriteLine(intMyArr.Length);
			Console.WriteLine(intMyArr.GetUpperBound(0));
		}

		public static void ArrayListTest()
		{
			ArrayList x = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
			x.TrimToSize();
			x.Add(18.5f);
			//PrintLine(x[0].GetType());
			//PrintLine(x[17]);
			//PrintLine(x[17].GetType());
		}

		public static void EnumerableTest()
		{
			IEnumerable<int> result = from value in Enumerable.Range(0, 20)
									  select value;

			// Loop.
			foreach (int value in result)
			{
				Console.WriteLine(value);
			}

			// We can use extension methods on IEnumerable<int>
			double average = result.Average();

		}
	}
}
