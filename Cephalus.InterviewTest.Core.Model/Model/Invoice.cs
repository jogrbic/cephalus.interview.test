using System;

namespace Cephalus.InterviewTest.Core.Model
{
	public class Invoice
	{
		public int Id { get; set; }
		public int AccuountId { get; set; }
		public DateTime TaxPointDate { get; set; }
		public string Reference { get; set; }
		public decimal TotalNet { get; set; }
		public decimal TotalVat { get; set; }
		public decimal TotalGross { get; set; }
		public int AccountId { get; set; }
	}
}
