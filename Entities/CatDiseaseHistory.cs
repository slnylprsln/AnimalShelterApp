using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CatDiseaseHistory
    {
        public int CatDiseaseHistoryId { get; set; }
        [ForeignKey("Cat")]
        public int? CatId { get; set; }
        public virtual Cat Cat { get; set; }
        public string? DiseaseName { get; set; }
        public DateTime? StartDate { get; set;}
        public DateTime? EndDate { get; set;}
    }
}
