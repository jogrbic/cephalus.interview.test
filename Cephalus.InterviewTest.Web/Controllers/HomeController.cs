using System.Diagnostics;
using Cephalus.InterviewTest.Api.Core;
using Microsoft.AspNetCore.Mvc;

namespace Cephalus.InterviewTest.Web.Controllers
{
	public class HomeController : Controller
    {
		private readonly IInvoiceService _invoiceService;

		public HomeController(IInvoiceService invoiceService)
		{
			_invoiceService = invoiceService;
		}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
