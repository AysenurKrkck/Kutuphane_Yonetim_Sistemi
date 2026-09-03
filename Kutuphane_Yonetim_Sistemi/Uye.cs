using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Yonetim_Sistemi
{
    public class Uye
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }

        public Uye(int id, string adSoyad, string telefon)
        {
            Id = id;
            AdSoyad = adSoyad;
            Telefon = telefon;
        }

    }
}
