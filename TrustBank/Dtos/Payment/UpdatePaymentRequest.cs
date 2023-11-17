using System.ComponentModel.DataAnnotations;

namespace TrustBank.Dtos.Payment
{
	public class UpdatePaymentRequest
	{
		[Required]
		public Guid Id { set; get; }
		[Required]
		public string? Name { set; get; }
		[Required]
		public string? Description { set; get; }
		[Required]
		public string? Status { set; get; }
		[Required]
		public string? Amount { set; get; }
		[Required]
		public string? Balance { set; get; }
		[Required]
		public string? PaymentType { set; get; }
	}
}
