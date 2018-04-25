using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
	public class ExceptionsTest
	{
		public static void SwallowException()
		{
			try
			{
				CatchExceptionAndRethrow();
			}
			catch (Exception ex)
			{
				var msg = ex.ToString();
			}
		}

		public static void CatchExceptionAndRethrow()
		{
			try
			{
				int x = 0;
				int y = 5 / x;
			}
			catch (Exception ex)
			{
				var msg = ex.ToString();

				//throw new DivideByZeroException(); // throw whatever you want
				// versus just throw or throw ex
				throw ex;
			}
			finally
			{

			}
		}
	}
}
