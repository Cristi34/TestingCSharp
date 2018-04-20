using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.DesignPatterns.PaymentFactory
{
	public class Product
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }

		public Product(string Name, decimal Price)
		{
			this.Name = Name;
			this.Price = Price;
		}

		public Product(string Name, string Description, decimal Price)
		{
			this.Name = Name;
			this.Price = Price;
			this.Description = Description;
		}

		public Product()
		{

		}
	}
}
