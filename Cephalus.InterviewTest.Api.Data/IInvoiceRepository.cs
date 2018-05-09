using Cephalus.InterviewTest.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cephalus.InterviewTest.Api.Data
{
	public interface IInvoiceRepository
    {
		IEnumerable<Invoice> GetAll();
		Task<IEnumerable<Invoice>> GetAllAsync();
	}
}
