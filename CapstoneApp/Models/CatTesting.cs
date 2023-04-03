using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneApp.Models
{
	public class CatTesting
	{
		public int CatTestingId { get; set; }
		public int? CatId { get; set; }
		public string? Name { get; set; }
		public DateTime? TestDate { get; set; }
		public string? TestResult { get; set; }
	}
}
