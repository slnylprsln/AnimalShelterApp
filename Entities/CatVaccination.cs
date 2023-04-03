using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class CatVaccination
    {
        public int CatVaccinationId { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Cat")]
        public int? CatId { get; set; }
        public virtual Cat Cat { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime VaccinationExpiryDate { get; set; }
    }
}
