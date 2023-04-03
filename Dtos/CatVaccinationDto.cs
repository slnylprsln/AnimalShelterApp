using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class CatVaccinationDto
    {
        public int CatVaccinationId { get; set; }
        public string? Name { get; set; }
        public int? CatId { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime VaccinationExpiryDate { get; set; }
    }
}
