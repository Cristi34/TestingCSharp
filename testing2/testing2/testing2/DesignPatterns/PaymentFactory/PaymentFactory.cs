using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.DesignPatterns.PaymentFactory
{
	public class PaymentFactory
	{
		IPaymentGateway gateway = null;

		public void MakePayment(PaymentMethod method, Product product)
		{
			PaymentGatewayFactory factory = new PaymentGatewayFactory();
			this.gateway = factory.CreatePaymentGateway(method, product);

			this.gateway.MakePayment(product);
		}

		public static void PaymentFactoryTest()
		{
			var paymentFactory = new PaymentFactory();
			var product1 = new Product
			{
				Name = "Colgate",
				Description = "pasta de dinti",
				Price = 11
			};
			var product2 = new Product
			{
				Name = "Morgans",
				Description = "crema de barba",
				Price = 61
			};
			var product3 = new Product
			{
				Name = "Yves Rocher",
				Description = "spuma de ras",
				Price = 23
			};
			paymentFactory.MakePayment(DesignPatterns.PaymentMethod.PayPal, product1);
			paymentFactory.MakePayment(DesignPatterns.PaymentMethod.ING, product2);
			paymentFactory.MakePayment(DesignPatterns.PaymentMethod.PayPal, product2);
		}
	}
}
