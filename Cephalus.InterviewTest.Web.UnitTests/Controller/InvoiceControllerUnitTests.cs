using Cephalus.InterviewTest.Api.Core;
using Cephalus.InterviewTest.Api.Data;
using Cephalus.InterviewTest.Core.Model;
using Cephalus.InterviewTest.Web.Controllers;
using Cephalus.InterviewTest.Web.Model;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cephalus.InterviewTest.Web.UnitTests
{
	[TestFixture]
    public class InvoiceControllerUnitTests
    {
		private IInvoiceRepository _invoiceRepository;
		private IInvoiceService _invoiceService;

		[OneTimeSetUp]
		public void Setup()
		{
			_invoiceRepository = Substitute.For<IInvoiceRepository>();
			_invoiceService = Substitute.For<IInvoiceService>();
		}

		[Test]
		public async Task GetInvoicesAsync_ReturnsInvoiceCollectionFromDb()
		{
			_invoiceService.GetInvoicesAsync()
				.Returns(Task.FromResult(Enumerable.Empty<Invoice>()));

			var controller = CreateController();
			var result = await controller.GetInvoices();

			await _invoiceService.Received(1).GetInvoicesAsync();
			Assert.IsInstanceOf<IEnumerable<InvoiceModel>>(result);
		}

		private InvoiceController CreateController()
		{
			return new InvoiceController(_invoiceService);
		}
    }
}
