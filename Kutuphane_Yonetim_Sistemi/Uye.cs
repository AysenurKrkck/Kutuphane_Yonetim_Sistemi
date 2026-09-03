using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Yonetim_Sistemi
{
    public class Uye
    {
        public int Id { get; set; }// Üye ID
        public string AdSoyad { get; set; }// Üye Ad Soyad
        public string Telefon { get; set; }// Üye Telefon

        public Uye(int id, string adSoyad, string telefon)// Üye oluşturucu
        {
            Id = id;
            AdSoyad = adSoyad;
            Telefon = telefon;
        }

    }
}
