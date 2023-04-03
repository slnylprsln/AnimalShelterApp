using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneApp.Models
{
	public class CatVaccination
	{
		public int CatVaccinationId { get; set; }
		public string? Name { get; set; }
		public int? CatId { get; set; }
		public DateTime VaccinationDate { get; set; }
		public DateTime VaccinationExpiryDate { get; set; }
	}
}
