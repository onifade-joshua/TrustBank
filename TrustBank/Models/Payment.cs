namespace TrustBank.Models
{
	public class Payment
	{
		public Guid Id { set; get; }
		public string? Name { set; get; }
		public string? Description { set; get; }
		public string? Status { set; get; }
		public string? Amount { set; get; }
		public string? Balance { set; get; }
		public string? PaymentType { set; get; }
	}
}
