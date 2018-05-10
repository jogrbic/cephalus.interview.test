using Cephalus.InterviewTest.Api.Data;
using Cephalus.InterviewTest.Core.Model;
using Cephalus.InterviewTest.Data.Sql.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cephalus.InterviewTest.Data.Sql
{
	public class InvoiceRepositorySql : DbContext, IInvoiceRepository
	{
		private readonly string _connectionString;

		public InvoiceRepositorySql(string connectionString)
		{
			_connectionString = connectionString;
		}

		public InvoiceRepositorySql(DbContextOptions options)
			: base(options)
		{
		}

		public IEnumerable<Invoice> GetAll()
		{
			IQueryable<JoinedInvoiceAccount> invoiceCollection = GetAllInvoicesQueryable();

			return invoiceCollection.Select(invoice => ToInvoice(invoice.Invoice, invoice.Account));
		}

		public Task<IEnumerable<Invoice>> GetAllAsync()
		{
			IQueryable<JoinedInvoiceAccount> invoiceCollection = GetAllInvoicesQueryable();

			return invoiceCollection.ToArrayAsync()
				.ContinueWith((t) => t.Result.Select(invoice => ToInvoice(invoice.Invoice, invoice.Account)));
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AccountSql>().ToTable("Account");
			modelBuilder.Entity<InvoiceSql>().ToTable("Invoice");
		}

		private IQueryable<JoinedInvoiceAccount> GetAllInvoicesQueryable()
		{
			return from invoice in Set<InvoiceSql>()
				   join acc in Set<AccountSql>() on invoice.AccountId equals acc.AccountId into accounts
				   from invoiceAccounts in accounts.DefaultIfEmpty()
				   select new JoinedInvoiceAccount
				   {
					   Invoice = invoice,
					   Account = accounts.FirstOrDefault()
				   };
		}

		private Account ToAccount(AccountSql accountSql)
		{
			if (accountSql == null)
			{
				new ArgumentNullException(nameof(accountSql));
			}

			return new Account
			{
				AccountId = accountSql.AccountId,
				Address1 = accountSql.Address1,
				Address2 = accountSql.Address2,
				County = accountSql.County,
				Name = accountSql.Name,
				Postcode = accountSql.Postcode,
				Town = accountSql.Town
			};
		}

		private Invoice ToInvoice(InvoiceSql invoiceSql)
		{
			if (invoiceSql == null)
			{
				new ArgumentNullException(nameof(invoiceSql));
			}

			return new Invoice
			{
				Id = invoiceSql.InvoiceId,
				TaxPointDate = invoiceSql.TaxPointDate,
				AccountId = invoiceSql.AccountId,
				Reference = invoiceSql.Reference,
				TotalGross = invoiceSql.TotalGross,
				TotalNet = invoiceSql.TotalNet,
				TotalVat = invoiceSql.TotalVat,
			};
		}

		private Invoice ToInvoice(InvoiceSql invoiceSql, AccountSql accountSql)
		{
			var invoice = ToInvoice(invoiceSql);

			invoice.Account = ToAccount(accountSql);

			return invoice;
		}

		private class JoinedInvoiceAccount
		{
			public AccountSql Account { get; set; }
			public InvoiceSql Invoice { get; set; }
		}
	}
}
