using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class DonationDto
    {
        public int DonationId { get; set; }
        public int UserId { get; set; }
        public int ShelterId { get; set; }
        public Entities.Type Type { get; set; }
        public int Amount { get; set; }
        public bool? VerifiedYet { get; set; }
        public bool? Verification { get; set; }
    }
}
