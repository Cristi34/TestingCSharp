using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
	public class ExceptionsTest
	{
		public static void TestTryCatchFinally()
		{
			try
			{
				int x = 0;
				int y = 5 / x;
			}
			catch (Exception ex)
			{
				var msg = ex.ToString();
				//try
				//{
				throw new FormatException();
				//}
				//catch(Exception ex2)
				//{
				//    var msg2 = ex2.ToString();                    
				//}
			}
			finally
			{

			}
		}
	}
}
