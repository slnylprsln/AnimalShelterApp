using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Cat
    {
        public int CatId { get; set; }
        public string? ChipCode { get; set; }
        public string? Breed { get; set; }
        public string? Gender { get; set; }
        public DateTime Birthday { get; set; }
        [ForeignKey("Shelter")]
        public int? ShelterId { get; set; }
        public virtual Shelter Shelters { get; set; }
        public DateTime BroughtToShelter { get; set; }
        public int? UserId { get; set; }
        public DateTime? OwningDate { get; set; }
        public string? FertilityStatus { get; set; }
        public bool Pregnancy { get; set; }
        public ICollection<CatTesting> CatTestings { get; set; }
        public ICollection<CatDiseaseHistory> CatDiseaseHistories { get; set; }
        public ICollection<CatVaccination> CatVaccinations { get; set; }
    }
}
