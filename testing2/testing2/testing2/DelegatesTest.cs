using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
	public class DelegatesTest
	{
		public delegate void WriteToConsoleDelegate(string str);
		public static void DelegateTest()
		{
			WriteToConsoleDelegate del1 = new WriteToConsoleDelegate(WriteString);
			WriteToConsoleDelegate del2 = new WriteToConsoleDelegate(WritePaddedString);
			// or you can do this
			WriteToConsoleDelegate del3 = PrintAllCaps;

			var testString = "alabala";
			del1(testString);
			del2(testString);
			del3(testString);
		}

		private static void WriteString(string str)
		{
			Console.WriteLine("string: " + str);
		}
		private static void WritePaddedString(string str)
		{
			Console.WriteLine("string padded: " + "000000" + str);
		}
		private static void PrintAllCaps(string str)
		{
			Console.WriteLine("All Caps: " + str.ToUpper());
		}
	}
}
