namespace TrustBank.Dtos
{
	public class GenericResponse<T>
	{
		public string? Code { set; get; }
		public string? Message { set; get; }
		public T? Result { set; get; }
	}
}
