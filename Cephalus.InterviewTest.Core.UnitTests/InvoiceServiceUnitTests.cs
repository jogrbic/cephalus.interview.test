using Cephalus.InterviewTest.Api.Data;
using Cephalus.InterviewTest.Core.Model;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cephalus.InterviewTest.Core.UnitTests
{
	[TestFixture]
    public class InvoiceServiceUnitTests
    {
		private IInvoiceRepository _invoiceRepository;

		[OneTimeSetUp]
		public void Setup()
		{
			_invoiceRepository = Substitute.For<IInvoiceRepository>();
		}

		[Test]
		public void GetInvoices_InvoiceRepository_GetAllInvoicesCalled()
		{
			var service = new InvoiceService(_invoiceRepository);

			_invoiceRepository.GetAll().Returns(Enumerable.Empty<Invoice>());

			var results = service.GetInvoices();

			_invoiceRepository.Received(1).GetAll();
			Assert.IsInstanceOf<IEnumerable<Invoice>>(results);
		}

		[Test]
		public async Task GetInvoicesAsync_InvoiceRepository_GetAllInvoicesCalled()
		{
			var service = new InvoiceService(_invoiceRepository);

			_invoiceRepository.GetAllAsync().Returns(Enumerable.Empty<Invoice>());

			var results = await service.GetInvoicesAsync();

			_invoiceRepository.Received(1).GetAllAsync();

			Assert.IsInstanceOf<IEnumerable<Invoice>>(results);
		}
	}
}
