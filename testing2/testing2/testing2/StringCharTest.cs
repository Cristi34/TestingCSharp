using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
	public class StringCharTest
	{
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
		static void charIntCalcul()
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
