using Cephalus.InterviewTest.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cephalus.InterviewTest.Api.Core
{
	public interface IInvoiceService
    {
		IEnumerable<Invoice> GetInvoices();
		Task<IEnumerable<Invoice>> GetInvoicesAsync();
    }
}
