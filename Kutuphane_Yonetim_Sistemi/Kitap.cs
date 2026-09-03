using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Yonetim_Sistemi
{
    public class Kitap
    {
        public int Id { get; set; }// Kitap ID
        public string Baslik { get; set; }// Kitap Başlığı
        public string Yazar { get; set; }// Kitap Yazarı
        public string ISBN { get; set; }// Kitap ISBN
        public bool OduncVerildiMi { get; set; } = false;// Ödünç verildi mi?

        public Kitap(int id, string baslik, string yazar, string isbn)// Kitap oluşturucu
        {
            Id = id;
            Baslik = baslik;
            Yazar = yazar;
            ISBN = isbn;
        }
    }
}
