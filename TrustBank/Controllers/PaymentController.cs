using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;
using TrustBank.Dtos;
using TrustBank.Dtos.Payment;
using TrustBank.Extension;
using TrustBank.Interfaces;
using TrustBank.Models;

namespace TrustBank.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly IPaymentService _paymentService;
		private readonly ILogger<PaymentController> _logger;
		public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
		{
			_paymentService = paymentService;
			_logger = logger;
		}

		[HttpGet]
		[Route("all")]
		public ActionResult<List<Payment>> GetPayments()
		{
			_logger.LogInformation("Executing Getpayments");
			return _paymentService.GetPayments();
		}

		[HttpGet]
		[Route("getbyid/{paymentId}")]
		public ActionResult<GenericResponse<GetPaymentRequest>> GetPayment(string paymentId)
		{
			if (_paymentService.IsExisting(paymentId))
			{
				return NotFound($"Payment {paymentId} not found!");
			}
			else
			{
				var result = new GenericResponse<GetPaymentRequest>()
				{
					Code = "200",
					Message = "success",
					Result = _paymentService.GetPayment(paymentId).PaymentToGetPaymentRequest()
			    };
				return Ok(result);
			}
		}

		[HttpPost]
		[Route("add")]
		public ActionResult<Payment> AddPayment([FromBody] InitiatePaymentRequest paymentReq)
		{
			_logger.LogInformation("Executing Addpayments");

			if(!ModelState.IsValid)
			{
				return BadRequest();
			}

			var newPayment = new Payment
			{
				Name = paymentReq.Name,
				Id = paymentReq.Id,
				Description = paymentReq.Description,
				Amount = paymentReq.Amount,
				Status = paymentReq.Status,
				Balance = paymentReq.Balance,
				PaymentType = paymentReq.PaymentType,

			};
			var created = _paymentService.AddPayment(newPayment);
			return Ok(HttpStatusCode.Created);
		}

		[HttpPut]
		[Route("Update")]
		public ActionResult<Payment> UpdatePayment([FromBody]UpdatePaymentRequest updatePaymentReq)
		{
			_logger.LogInformation("Executing Updatepayments");
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var newUpdatePayment = new Payment
			{
				Name = updatePaymentReq.Name,
				Id = updatePaymentReq.Id,
				Description = updatePaymentReq.Description,
				Amount = updatePaymentReq.Amount,
				Status = updatePaymentReq.Status,
				Balance = updatePaymentReq.Balance,
				PaymentType = updatePaymentReq.PaymentType,

			};
			var updated = _paymentService.UpdatePayment(newUpdatePayment);
			return Ok(HttpStatusCode.Accepted);
		}

		[HttpDelete]
		[Route("delete/{paymentId}")]
		public ActionResult<bool> DeletePayment(string paymentId)
		{
			if (_paymentService.IsExisting(paymentId))
			{
				return NotFound($"Payment {paymentId} not found!");
			}
			else
			{
				return Ok(_paymentService.Delete(paymentId));
			}
		}
	}
}
