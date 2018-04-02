using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
	public class ImmutableObjectsTest
	{
		public static void ImmutableDateTime()
		{
			DateTime dt = DateTime.Now;
			Console.WriteLine(dt);

			dt = DateTime.Now;
			Console.WriteLine(dt);

			// The DateTime object itself is immutable, but not the reference dt. dt is allowed to change which DateTime object it points to. 
			// The immutability refers to the fact we can't change the variables inside a DateTime object.
			// For example, we can't go:
			// dt.Day = 3;

			// dt itself is just a reference variable that points towards a DateTime object. By its definition, it's allowed to vary.
		}
	}
}
