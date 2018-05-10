using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cephalus.InterviewTest.Data.Sql.Model
{
	[Table("Account")]
	internal class AccountSql
    {
		[Key]
		public int AccountId { get; set; }
		public string Name { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string Town { get; set; }
		public string County { get; set; }
		public string Postcode { get; set; }
	}
}
