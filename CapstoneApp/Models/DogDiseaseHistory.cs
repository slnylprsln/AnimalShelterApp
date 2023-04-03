using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneApp.Models
{
	public class DogDiseaseHistory
	{
		public int DogDiseaseHistoryId { get; set; }
		public int? DogId { get; set; }
		public string? DiseaseName { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
	}
}
