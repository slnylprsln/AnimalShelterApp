using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class DogVaccinationDto
    {
        public int DogVaccinationId { get; set; }
        public string? Name { get; set; }
        public int? DogId { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime VaccinationExpiryDate { get; set; }
    }
}
