using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DogDiseaseHistory
    {
        public int DogDiseaseHistoryId { get; set; }
        [ForeignKey("Dog")]
        public int? DogId { get; set; }
        public virtual Dog Dog { get; set; }
        public string? DiseaseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
