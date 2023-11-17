using Newtonsoft.Json;
using System.Net;
using TrustBank.Models;

namespace TrustBank.MiddleWares
{
	public class ExceptionMiddleWare : IMiddleware
	{
		private readonly ILogger<ExceptionMiddleWare> _logger;

		public ExceptionMiddleWare(ILogger<ExceptionMiddleWare> logger)
		{
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An unhandled exception occurred.");

				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				ProblemDetails problemDetails = new()
				{
					Detail = "An internal server error occurred",
					Status = (int)HttpStatusCode.InternalServerError,
					Type = "Server Error"
				};
				string json = JsonConvert.SerializeObject(problemDetails);
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(json);
				return; // Return to avoid further processing
			}
		}
	}
}
