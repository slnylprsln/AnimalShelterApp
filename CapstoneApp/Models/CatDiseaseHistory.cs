using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneApp.Models
{
	public class CatDiseaseHistory
	{
		public int CatDiseaseHistoryId { get; set; }
		public int? CatId { get; set; }
		public string? DiseaseName { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
	}
}
