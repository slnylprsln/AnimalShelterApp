using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class DogDiseaseHistoryDto
    {
        public int DogDiseaseHistoryId { get; set; }
        public int? DogId { get; set; }
        public string? DiseaseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
