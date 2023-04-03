using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Donation
    {
        public int DonationId { get; set; }
        public int UserId { get; set; }
        public int ShelterId { get; set; }
        public Type Type { get; set; }
        public int Amount { get; set; }
        public bool? VerifiedYet { get; set; }
        public bool? Verification { get; set; }
    }

    public enum Type
    {
        Kedi_Maması,
        Köpek_Maması,
        Kuduz_Aşısı,
        Kombinasyon_Aşısı,
        Parvovirüs_Aşısı,
        Distemper_Aşısı,
        Hepatit_Aşısı
    }
}
