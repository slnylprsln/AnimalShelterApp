using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class CatTestingDto
    {
        public int CatTestingId { get; set; }
        public int? CatId { get; set; }
        public string? Name { get; set; }
        public DateTime? TestDate { get; set; }
        public string? TestResult { get; set; }
    }
}
