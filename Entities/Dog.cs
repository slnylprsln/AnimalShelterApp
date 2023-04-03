using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Dog
    {
        public int DogId { get; set; }
        public String? ChipCode { get; set; }
        public String? Breed { get; set; }
        public String? Gender { get; set; }
        public DateTime Birthday { get; set; }
        [ForeignKey("Shelter")]
        public int? ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }
        public DateTime BroughtToShelter { get; set; }
        public int? UserId { get; set; }
        public DateTime? OwningDate { get; set; }
        public string? FertilityStatus { get; set; }
        public bool? Pregnancy { get; set; }
        public ICollection<DogTesting> DogTestings { get; set; }
        public ICollection<DogDiseaseHistory> DogDiseaseHistories { get; set; }
        public ICollection<DogVaccination> DogVaccinations { get; set; }
    }
}
