using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneApp.Models
{
    public class Follow
    {
        public int FollowId { get; set; }
        public int UserId { get; set; }
        public int AnimalId { get; set; }
        public AnimalType AnimalType { get; set; }
    }

    public enum AnimalType
    {
        Kedi,
        Köpek
    }
}
