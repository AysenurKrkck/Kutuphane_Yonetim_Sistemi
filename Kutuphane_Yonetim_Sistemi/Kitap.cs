using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Yonetim_Sistemi
{
    public class Kitap
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Yazar { get; set; }
        public string ISBN { get; set; }
        public bool OduncVerildiMi { get; set; } = false;

        public Kitap(int id, string baslik, string yazar, string isbn)
        {
            Id = id;
            Baslik = baslik;
            Yazar = yazar;
            ISBN = isbn;
        }
    }
}
