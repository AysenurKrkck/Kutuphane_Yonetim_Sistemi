using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Yonetim_Sistemi
{
    public class Kutuphane
    {
        public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();// Kitap listesi
        public List<Uye> Uyeler { get; set; } = new List<Uye>();// Üye listesi
        public List<OduncIslemi> Islemler { get; set; } = new List<OduncIslemi>();// Ödünç işlem listesi

        private const int OduncSuresiGun = 14;// Ödünç alma süresi 14 gün
        private const decimal GunlukCeza = 5.0m; // Günlük 5 TL gecikme bedeli

        // 1. Kitap Ekleme
        public void KitapEkle(Kitap kitap) => Kitaplar.Add(kitap);

        // 2. Kitap Listeleme
        public void KitaplariListele()
        {
            Console.WriteLine("\n--- Kütüphane Kitap Listesi ---");
            if (Kitaplar.Count == 0)
            {
                Console.WriteLine("Kütüphanede henüz kayıtlı kitap yok.");
                return;
            }

            foreach (var k in Kitaplar)
            {
                string durum = k.OduncVerildiMi ? "[Ödünç Verildi]" : "[Rafta]";
                Console.WriteLine($"{k.Id} - {k.Baslik} | {k.Yazar} | {k.ISBN} {durum}");
            }
        }

        // 3. Üye Ekleme
        public void UyeEkle(Uye uye) => Uyeler.Add(uye);

        public void UyeleriListele()
        {
            Console.WriteLine("\n--- Kayıtlı Üyeler Listesi ---");
            if (Uyeler.Count == 0)
            {
                Console.WriteLine("Sistemde henüz kayıtlı üye bulunmuyor.");
                return;
            }

            foreach (var u in Uyeler)
            {
                // Üyenin şu anda elinde teslim etmediği kitap sayısı
                int aktifKitapSayisi = Islemler.Count(i => i.IslemiYapanUye.Id == u.Id && i.TeslimTarihi == null);

                Console.WriteLine($"ID: {u.Id} | Ad Soyad: {u.AdSoyad} | Telefon: {u.Telefon} | Aktif Kitap: {aktifKitapSayisi} adet");
            }
        }

        // 4. Kitap Ödünç Alma
        public bool KitapOduncVer(int kitapId, int uyeId)
        {
            var kitap = Kitaplar.FirstOrDefault(k => k.Id == kitapId);// Kitap ID'sine göre kitap bulma
            var uye = Uyeler.FirstOrDefault(u => u.Id == uyeId);// Üye ID'sine göre üye bulma

            if (kitap == null || uye == null)
            {
                Console.WriteLine("Kitap veya üye bulunamadı.");
                return false;
            }

            if (kitap.OduncVerildiMi)
            {
                Console.WriteLine("Bu kitap zaten ödünç verilmiş.");
                return false;
            }

            kitap.OduncVerildiMi = true;// Kitap ödünç verildi olarak işaretleme
            int islemId = Islemler.Count + 1;// Yeni işlem ID'si oluşturma
            Islemler.Add(new OduncIslemi(islemId, kitap, uye));// Yeni ödünç işlemi ekleme
            Console.WriteLine($"'{kitap.Baslik}' adlı kitap {uye.AdSoyad} isimli üyeye ödünç verildi.");
            return true;
        }

        // 5 & 6. Kitap Teslim Etme ve Gecikme Cezası Hesaplama
        public void KitapTeslimAl(int kitapId)
        {
            var islem = Islemler.FirstOrDefault(i => i.OduncAlinanKitap.Id == kitapId && i.TeslimTarihi == null);// Kitap ID'sine göre aktif ödünç işlemi bulma

            if (islem == null)
            {
                Console.WriteLine("Bu kitaba ait aktif bir ödünç kaydı bulunamadı.");
                return;
            }

            islem.TeslimTarihi = DateTime.Now;// Teslim tarihi olarak şimdiki zamanı atama
            islem.OduncAlinanKitap.OduncVerildiMi = false;// Kitap artık ödünç verilmiş değil olarak işaretleme

            // 14 günü aşan her gün için ceza hesaplama
            TimeSpan gecenSure = islem.TeslimTarihi.Value - islem.AlmaTarihi;
            if (gecenSure.TotalDays > OduncSuresiGun)
            {
                int gecikmeGunu = (int)Math.Ceiling(gecenSure.TotalDays - OduncSuresiGun);// Gecikme gün sayısını hesaplama
                islem.CezaTutari = gecikmeGunu * GunlukCeza;// Ceza tutarını hesaplama
                Console.WriteLine($"Kitap {gecikmeGunu} gün gecikmiştir. Ceza Tutarı: {islem.CezaTutari:C}");// Ceza tutarını kullanıcıya gösterme
            }
            else
            {
                Console.WriteLine("Kitap zamanında teslim edildi. Ceza bulunmuyor.");
            }
        }

        // 7. Kitap Arama (.NET Framework uyumlu IndexOf)
        public void KitapAra(string kelime)
        {
            var sonuc = Kitaplar.Where(k => (k.Baslik != null && k.Baslik.IndexOf(kelime, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                            (k.Yazar != null && k.Yazar.IndexOf(kelime, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();// Kitap başlığı veya yazar adına göre arama yapma

            Console.WriteLine($"\n--- Kitap Arama Sonuçları ({kelime}) ---");// Arama sonuçlarını kullanıcıya gösterme
            if (sonuc.Count == 0)
            {
                Console.WriteLine("Eşleşen kitap bulunamadı.");
                return;
            }

            sonuc.ForEach(k => Console.WriteLine($"{k.Id} - {k.Baslik} ({k.Yazar})"));// Eşleşen kitapları listeleme
        }

        // 8. Üye Arama (.NET Framework uyumlu IndexOf)
        public void UyeAra(string ad)
        {
            var sonuc = Uyeler.Where(u => u.AdSoyad != null &&
                                          u.AdSoyad.IndexOf(ad, StringComparison.OrdinalIgnoreCase) >= 0).ToList();// Üye adına göre arama yapma

            Console.WriteLine($"\n--- Üye Arama Sonuçları ({ad}) ---");
            if (sonuc.Count == 0)// Eşleşen üye bulunamadığında kullanıcıya bilgi verme
            {
                Console.WriteLine("Eşleşen üye bulunamadı.");
                return;
            }

            sonuc.ForEach(u => Console.WriteLine($"{u.Id} - {u.AdSoyad} ({u.Telefon})"));
        }

        // 9. Ödünç Geçmişi
        public void GecmisiListele()
        {
            Console.WriteLine("\n--- Ödünç İşlem Geçmişi ---");
            if (Islemler.Count == 0)
            {
                Console.WriteLine("Henüz yapılmış bir ödünç işlemi yok.");
                return;
            }

            foreach (var i in Islemler)// Ödünç işlemlerini listeleme
            {
                string durum = i.TeslimTarihi.HasValue ? $"Teslim Edildi ({i.TeslimTarihi:dd.MM.yyyy})" : "Hâlâ Üyede";// Teslim tarihi varsa teslim edildi, yoksa hâlâ üyede olarak gösterme
                Console.WriteLine($"İşlem #{i.Id}: Üye: {i.IslemiYapanUye.AdSoyad} | Kitap: {i.OduncAlinanKitap.Baslik} | Alış: {i.AlmaTarihi:dd.MM.yyyy} | Durum: {durum} | Ceza: {i.CezaTutari:C}");// Ödünç işlemi detaylarını kullanıcıya gösterme
            }
        }

        // 10. Kitap ve Üye Silme
        public void KitapSil(string isbn)
        {
            var kitap = Kitaplar.FirstOrDefault(k => k.ISBN == isbn);// ISBN numarasına göre kitap bulma

            if (kitap == null)
            {
                Console.WriteLine("Bu ISBN numarasına ait kitap bulunamadı.");
                return;
            }

            if (kitap.OduncVerildiMi)
            {
                Console.WriteLine("Bu kitap şu anda bir üyede ödünçte olduğu için silinemez!");
                return;
            }

            Kitaplar.Remove(kitap);
            Console.WriteLine($"'{kitap.Baslik}' adlı kitap başarıyla silindi.");
        }

        public void UyeSil(int uyeId)// Üye silme işlemi
        {
            bool aktifKitabiVar = Islemler.Any(i => i.IslemiYapanUye.Id == uyeId && i.TeslimTarihi == null);// Üyenin hâlâ teslim etmediği kitap var mı kontrol etme
            if (aktifKitabiVar)
            {
                Console.WriteLine("Üyenin teslim etmediği kitap(lar) var, silme işlemi yapılamaz!");
                return;
            }

            var uye = Uyeler.FirstOrDefault(u => u.Id == uyeId);// Üye ID'sine göre üye bulma
            if (uye != null)// Üye bulunduysa silme işlemi yapma
            {
                Uyeler.Remove(uye);
                Console.WriteLine("Üye başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Üye bulunamadı.");
            }
        }
    }
}
