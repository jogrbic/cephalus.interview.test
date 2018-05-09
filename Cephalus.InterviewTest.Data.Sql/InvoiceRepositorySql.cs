using Cephalus.InterviewTest.Api.Data;
using Cephalus.InterviewTest.Core.Model;
using Cephalus.InterviewTest.Data.Sql.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cephalus.InterviewTest.Data.Sql
{
	public class InvoiceRepositorySql : DbContext, IInvoiceRepository
	{
		public InvoiceRepositorySql(DbContextOptions options)
			: base(options)
		{
		}

		private DbSet<InvoiceSql> Invoices { get; set; }

		public IEnumerable<Invoice> GetAll()
		{
			return Set<InvoiceSql>().Select(invoice => ToCore(invoice)).ToArray();
		}

		public Task<IEnumerable<Invoice>> GetAllAsync()
		{
			return Invoices.ToArrayAsync().ContinueWith((t) => t.Result.Select(invoice => ToCore(invoice)));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<InvoiceSql>().ToTable("Invoice");
		}
		
		// TODO: potentially use auto mapping framework
		private Invoice ToCore(InvoiceSql invoiceSql)
		{
			return new Invoice
			{
				Id = invoiceSql.InvoiceId,
				TaxPointDate = invoiceSql.TaxPointDate,
				AccuountId = invoiceSql.AccountId,
				Reference = invoiceSql.Reference,
				TotalGross = invoiceSql.TotalGross,
				TotalNet = invoiceSql.TotalNet,
				TotalVat = invoiceSql.TotalVat
			};
		}
	}
}
