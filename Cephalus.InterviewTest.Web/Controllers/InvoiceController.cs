using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cephalus.InterviewTest.Api.Core;
using Cephalus.InterviewTest.Web.Model;
using Microsoft.AspNetCore.Mvc;

namespace Cephalus.InterviewTest.Web.Controllers
{
	[Route("api/[controller]")]
    public class InvoiceController : Controller
    {
		private readonly IInvoiceService _invoiceService;

		public InvoiceController(IInvoiceService invoiceService)
		{
			_invoiceService = invoiceService;
		}

		[HttpGet("[action]")]
		public async Task<IEnumerable<InvoiceModel>> GetInvoices()
		{
			return await _invoiceService
				.GetInvoicesAsync()
				.ContinueWith((result) => result.Result.Select(invoice => ToInvoiceModel(invoice)));
		}

		private static InvoiceModel ToInvoiceModel(Core.Model.Invoice invoice)
		{
			return new InvoiceModel
			{
				AccountId = invoice.AccountId,
				Id = invoice.Id,
				Reference = invoice.Reference,
				TaxPointDate = invoice.TaxPointDate,
				TotalGross = invoice.TotalGross,
				TotalNet = invoice.TotalNet,
				TotalVat = invoice.TotalVat,
				Address = invoice.GetAddress(),
				Name = invoice.GetName()
			};
		}
	}
}
