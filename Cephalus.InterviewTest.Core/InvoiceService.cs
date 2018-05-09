using Cephalus.InterviewTest.Api.Core;
using Cephalus.InterviewTest.Api.Data;
using Cephalus.InterviewTest.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cephalus.InterviewTest.Core
{
	public class InvoiceService : IInvoiceService
	{
		private IInvoiceRepository _invoiceRepository;

		public InvoiceService(IInvoiceRepository invoiceRepository)
		{
			_invoiceRepository = invoiceRepository;
		}

		public IEnumerable<Invoice> GetInvoices()
		{
			return _invoiceRepository.GetAll();
		}

		public async Task<IEnumerable<Invoice>> GetInvoicesAsync()
		{
			return await _invoiceRepository.GetAllAsync();
		}
	}
}
