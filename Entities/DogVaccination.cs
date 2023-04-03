using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class DogVaccination
    {
        public int DogVaccinationId { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Dog")]
        public int? DogId { get; set; }
        public virtual Dog Dog { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime VaccinationExpiryDate { get; set; }
    }
}
