using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingCSharp.DesignPatterns.PaymentFactory;

namespace TestingCSharp
{
	public class CastingTest
	{
		public static void CastStuff()
		{
			string numberString = "2";
			int converted1 = int.Parse(numberString);
			bool success = int.TryParse(numberString, out int converted2);
			// Convert.ToInt32() does not throw ArgumentNullException when its argument is null the way Int32.Parse() does
			int converted4 = Convert.ToInt32(numberString);

			double doubleVar = 5;
			int converted5 = (int)doubleVar;

			var backToString = converted2.ToString();
			//int? converted3 = numberString as int?;

			ArrayList arrayList = new ArrayList();
			arrayList.Add(new Product
			{
				Name = "Sensodyne",
				Description = "Toothpaste",
				Price = 13
			});
			arrayList.Add(new Product
			{
				Name = "STR8",
				Description = "Deodorant",
				Price = 34
			});
			arrayList.Add(new Car
			{
				HorsePower = 455
			});

			foreach(var item in arrayList)
			{
				var product = item as Product;
				if(product != null)
				{
					Console.WriteLine("product name: " + product.Name);
				}
			}
		}
	}
}
