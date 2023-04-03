using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
	public class Cat
	{
		public int CatId { get; set; }
		public string? ChipCode { get; set; }
		public string? Breed { get; set; }
		public string? Gender { get; set; }
		public DateTime Birthday { get; set; }
		public int? ShelterId { get; set; }
		public DateTime BroughtToShelter { get; set; }
		public int? UserId { get; set; }
		public DateTime? OwningDate { get; set; }
		public string? FertilityStatus { get; set; }
		public bool Pregnancy { get; set; }
	}
}
