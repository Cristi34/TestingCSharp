using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.DesignPatterns.PaymentFactory
{
	public class PaymentGatewayFactory
	{
		public virtual IPaymentGateway CreatePaymentGateway(PaymentMethod method, Product product)
		{
			IPaymentGateway gateway = null;

			switch (method)
			{
				case PaymentMethod.PayPal:
					gateway = new Bank_PayPal();
					break;
				case PaymentMethod.ING:
					gateway = new Bank_ING();
					break;
				//case PaymentMethod.BEST_FOR_ME:
				//	if (product.Price < 50)
				//	{
				//		gateway = new BankTwo();
				//	}
				//	else
				//	{
				//		gateway = new BankOne();
				//	}
				//	break;
			}

			return gateway;
		}
	}
}
