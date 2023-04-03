using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
	public class Shelter
	{
		public int ShelterId { get; set; }
		public string? Name { get; set; }
		public int? UserId { get; set; }
		public string? CertificateNo { get; set; }
		public string? City { get; set; }
		public string? Address { get; set; }
		public DateTime OpeningDate { get; set; }
		public int CatFoodStock { get; set; }
		public int DogFoodStock { get; set; }
		public int RabiesVaccineStock { get; set; }
		public int CombinationVaccineStock { get; set; }
		public int ParvovirusVaccineStock { get; set; }
		public int DistemperVaccineStock { get; set; }
		public int HepatitisVaccineStock { get; set; }
	}
}
