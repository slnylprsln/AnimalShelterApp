using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DogTesting
    {
        public int DogTestingId { get; set; }
        [ForeignKey("Dog")]
        public int? DogId { get; set; }
        public virtual Dog Dog { get; set; }
        public string? Name { get; set; }
        public DateTime TestDate { get; set; }
        public string? TestResult { get; set; }
    }
}
