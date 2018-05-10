using System;

namespace Cephalus.InterviewTest.Web.Model
{
	public class InvoiceModel
	{
		public int Id { get; set; }
		public int AccountId { get; set; }
		public DateTime TaxPointDate { get; set; }
		public string Reference { get; set; }
		public decimal TotalNet { get; set; }
		public decimal TotalVat { get; set; }
		public decimal TotalGross { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
	}
}
