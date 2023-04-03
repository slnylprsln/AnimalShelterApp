using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
	public class DogTesting
	{
		public int DogTestingId { get; set; }
		public int? DogId { get; set; }
		public string? Name { get; set; }
		public DateTime TestDate { get; set; }
		public string? TestResult { get; set; }
	}
}
