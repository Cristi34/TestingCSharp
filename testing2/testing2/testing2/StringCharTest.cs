using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
	public class StringCharTest
	{

		public static void StringCompareTest()
		{
			string s1 = "foobar";
			string s2 = "foobar";
			if (s1.Equals(s2))
				Console.WriteLine("They are the same.");
			else
				Console.WriteLine("They are not the same.");

			Console.WriteLine(s1.CompareTo(s2)); // returns 0
			s2 = "foofoo";
			Console.WriteLine(s1.CompareTo(s2)); // returns -1
			s2 = "fooaar";
			Console.WriteLine(s1.CompareTo(s2)); // returns 1

			int compVal = String.Compare(s1, s2);
			switch (compVal)
			{
				case 0:
					Console.WriteLine(s1 + " " + s2 + " are equal");
			break;
				case 1:
					Console.WriteLine(s1 + " is less than " + s2);
					break;
				case 2:
					Console.WriteLine(s1 + " is greater than " + s2);
			break;
				default:
					Console.WriteLine("Can't compare");
					break;
			}
		}
		public static void StringSplit()
		{
			string data = "Mike,McMillan,3000 W. Scenic,North Little Rock,AR,72118";
			char[] delimiter = { ',' };

			// here we need to pass a char array
			var sdata = data.Split(delimiter, 2);
			// The elements in the sdata array are:	
			//  0th element—Mike 
			//	1st element—McMillan,3000 W.Scenic,North Little Rock,AR,72118
		}

		static void Days1()
		{
			var days = "MTWTFSS";
			//var daysArray = days.ToCharArray().Cast<string>().ToArray();
			var daysArray = days.ToCharArray().Select(c => c.ToString()).ToArray();
			for (var i = 0; i < daysArray.Length; i++)
			{
				switch (daysArray[i])
				{
					case "M":
						daysArray[i] = "Monday";
						break;
					case "T":
						daysArray[i] = "Tuesday";
						break;
					case "W":
						daysArray[i] = "Wednesday";
						break;
					case "R":
						daysArray[i] = "Thursday";
						break;
					case "F":
						daysArray[i] = "Friday";
						break;
					case "S":
						daysArray[i] = "Saturday";
						break;
					case "U":
						daysArray[i] = "Sunday";
						break;
				}
			}
			daysArray[daysArray.Length - 1] = "and " + daysArray[daysArray.Length - 1];
			Console.WriteLine(string.Join(", ", daysArray));
		}
		static void CharIntCalcul()
		{
			char l = 'k';
			float b = 19.0f;
			int c;

			//ASCII k=107
			c = Convert.ToInt32(l / b);
			Console.WriteLine(c);

			// note
			float x = (float)12.502d;
			float y = 2.123456789f;
			double q = 14.45654764;
			double w = 13.45678D;

			Console.Write("12.123456789f = " + y);
		}
	}
}
