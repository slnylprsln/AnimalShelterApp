using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class DogDto
    {
        public int DogId { get; set; }
        public String? ChipCode { get; set; }
        public String? Breed { get; set; }
        public String? Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int? ShelterId { get; set; }
        public DateTime BroughtToShelter { get; set; }
        public int? UserId { get; set; }
        public DateTime? OwningDate { get; set; }
        public string? FertilityStatus { get; set; }
        public bool? Pregnancy { get; set; }
    }
}
