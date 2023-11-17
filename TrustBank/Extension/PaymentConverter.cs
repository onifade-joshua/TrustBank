using TrustBank.Dtos.Payment;
using TrustBank.Models;


namespace TrustBank.Extension
{
	public static class PaymentConverter
	{
		public static GetPaymentRequest PaymentToGetPaymentRequest(this Payment payment)
		{
			return new GetPaymentRequest()
			{
				Name = payment.Name,
				Id = payment.Id,
				Description = payment.Description,
				Amount = payment.Amount,
				Status = payment.Status,
				Balance = payment.Balance,
				PaymentType = payment.PaymentType,
			};

		}
	}
}
