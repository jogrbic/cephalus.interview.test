using System;
using System.ComponentModel.DataAnnotations;

namespace Cephalus.InterviewTest.Data.Sql.Model
{
	internal class InvoiceSql
	{
		[Key]
		public int InvoiceId { get; internal set; }
		public int AccountId { get; set; }
		public DateTime TaxPointDate { get; internal set; }
		public string Reference { get; set; }
		public decimal TotalNet { get; set; }
		public decimal TotalVat { get; set; }
		public decimal TotalGross { get; set; }
	}
}
