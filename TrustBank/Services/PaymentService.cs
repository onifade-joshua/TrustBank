using TrustBank.Interfaces;
using TrustBank.Models;
using TrustBank.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TrustBank.Services
{
	public class PaymentService : IPaymentService
	{
		private static List<Payment> payments =
		new()
		{
			new Payment()
			{
				Id = Guid.NewGuid(),
				Name = "Abioye David",
				Description = "Payment transfer of groceries",
				Status = "Sent",
				Amount = "25,000",
				Balance = "50,000",
				PaymentType = "Transfer"
			},
			new Payment()
			{
				Id = Guid.NewGuid(),
				Name = "Obama Sanusi",
				Description = "Payment transfer of clothes",
				Status = "Sent",
				Amount = "15,000",
				Balance = "70,000",
				PaymentType = "Deposit"
			},
			new Payment()
			{
				Id = Guid.NewGuid(),
				Name = "George Kimberly",
				Description = "Payment transfer of shoes",
				Status = "Sent",
				Amount = "35,000",
				Balance = "100,000",
				PaymentType = "Transfer"
			}
		};
		public Payment AddPayment(Payment payment)
		{
			payments.Add(payment);
			return payment;
		}

		public bool Delete(string paymentId)
		{
			
			var Deleted = payments.Where(m => m.Id.ToString() == paymentId).SingleOrDefault();
			payments.Remove(Deleted ?? new Payment());
			return true;
		}

		public Payment GetPayment(string paymentId)
		{
			var Exist = payments.Where(m => m.Id.ToString() == paymentId).SingleOrDefault();
			return Exist ?? new Payment();
		}

		public List<Payment> GetPayments()
		{
			return payments;
		}

		public bool IsExisting(string paymentId)
		{
			var IsExisting = payments.Where(m => m.Id.ToString() == paymentId).SingleOrDefault();
			return IsExisting ==  null ? true : false;
		}

		public Payment UpdatePayment(Payment payment)
		{
			Payment UpdatedPayment = new Payment();
			foreach(Payment pay  in payments)
			{
				if(pay.Id == payment.Id)
				{
					pay.Name = payment.Name;
					pay.Description = payment.Description;
					pay.Status = payment.Status;
					pay.Amount = payment.Amount;
					pay.Balance = payment.Balance;
					pay.PaymentType = payment.PaymentType;
					UpdatedPayment = pay;
					break;
				}
			}
			return UpdatedPayment;
		}
	}
}
