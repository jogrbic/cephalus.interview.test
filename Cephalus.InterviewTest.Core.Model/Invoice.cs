using System;
using System.Linq;

namespace Cephalus.InterviewTest.Core.Model
{
	public class Invoice
	{
		public int Id { get; set; }
		public int AccountId { get; set; }
		public Account Account { get; set; }
		public DateTime TaxPointDate { get; set; }
		public string Reference { get; set; }
		public decimal TotalNet { get; set; }
		public decimal TotalVat { get; set; }
		public decimal TotalGross { get; set; }

		public string GetAddress()
		{
			var addressBits = new[] { Account?.Address1, Account?.Address2, Account.Postcode, Account.Town, Account.County };

			return string.Join(", ", addressBits.Where(b => !string.IsNullOrEmpty(b)));
		}

		public string GetName()
		{
			return Account?.Name;
		}
	}
}
