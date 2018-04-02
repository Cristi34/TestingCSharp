using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing2.DesignPatterns.PaymentFactory
{
	public class PaymentFactoryTest
	{
		IPaymentGateway gateway = null;

		public void MakePayment(PaymentMethod method, Product product)
		{
			PaymentGatewayFactory factory = new PaymentGatewayFactory();
			this.gateway = factory.CreatePaymentGateway(method, product);

			this.gateway.MakePayment(product);
		}
	}
}
