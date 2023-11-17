using TrustBank.Models;



namespace TrustBank.Interfaces
{
	public interface IPaymentService
	{
		Payment AddPayment(Payment payment);
		Payment UpdatePayment(Payment payment);
		bool Delete(string  paymentId);
		Payment GetPayment(string paymentId);
		List<Payment> GetPayments();
		bool IsExisting(string paymentId);
	}
}
