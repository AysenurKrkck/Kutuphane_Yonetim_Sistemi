using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Yonetim_Sistemi
{
    public class OduncIslemi
    {
        public int Id { get; set; }// Ödünç işlem ID
        public Kitap OduncAlinanKitap { get; set; }// Ödünç alınan kitap
        public Uye IslemiYapanUye { get; set; }// Ödünç işlemi yapan üye
        public DateTime AlmaTarihi { get; set; }// Ödünç alma tarihi
        public DateTime? TeslimTarihi { get; set; } // Null ise henüz teslim edilmedi
        public decimal CezaTutari { get; set; } = 0;// Gecikme cezası

        public OduncIslemi(int id, Kitap kitap, Uye uye)// Ödünç işlem oluşturucu
        {
            Id = id;
            OduncAlinanKitap = kitap;
            IslemiYapanUye = uye;
            AlmaTarihi = DateTime.Now;
        }
    }
}
