using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingCSharp.DesignPatterns.PaymentFactory;

namespace TestingCSharp
{
	public class GenericsTest
	{
		public static void GenericTestDemo()
		{
			// this only works if we define the generic filter as: where T: new()
			// GenericReferenceType<int> integer = new GenericReferenceType<int>();
			GenericReferenceType<object> objecttest = new GenericReferenceType<object>();
			GenericReferenceType<Product> product = new GenericReferenceType<Product>();
		}		
	}

	public class GenericReferenceType<T> where T: class 
	{
		public GenericReferenceType()
		{
			Console.WriteLine("this type is: " + this.GetType().ToString());
		}
	}

	public class GenericTypeInterface<T> where T: ITest
	{

	}

	public interface ITest
	{

	}
}
