using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CatTesting
    {
        public int CatTestingId { get; set; }
        [ForeignKey("Cat")]
        public int? CatId { get; set; }
        public virtual Cat Cat { get; set; }
        public string? Name { get; set; }
        public DateTime? TestDate { get; set; }
        public string? TestResult { get; set; }
    }
}
