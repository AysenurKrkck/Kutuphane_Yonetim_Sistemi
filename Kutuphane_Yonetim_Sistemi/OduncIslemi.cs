using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Yonetim_Sistemi
{
    public class OduncIslemi
    {
        public int Id { get; set; }
        public Kitap OduncAlinanKitap { get; set; }
        public Uye IslemiYapanUye { get; set; }
        public DateTime AlmaTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; } // Null ise henüz teslim edilmedi
        public decimal CezaTutari { get; set; } = 0;

        public OduncIslemi(int id, Kitap kitap, Uye uye)
        {
            Id = id;
            OduncAlinanKitap = kitap;
            IslemiYapanUye = uye;
            AlmaTarihi = DateTime.Now;
        }
    }
}
