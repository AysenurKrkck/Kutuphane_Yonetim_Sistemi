using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Yonetim_Sistemi
{
    public class Program
    {
        static void Main(string[] args)
        {
            Kutuphane yonetim = new Kutuphane();// Kütüphane yönetim sistemi nesnesi oluşturuluyor

            // Başlangıç verileri
            yonetim.KitapEkle(new Kitap(1, "Nutuk", "Mustafa Kemal Atatürk", "978975"));
            yonetim.KitapEkle(new Kitap(2, "Suç ve Ceza", "Dostoyevski", "978605"));
            yonetim.UyeEkle(new Uye(1, "Ahmet Yılmaz", "05551112233"));

            while (true)// Ana menü döngüsü 
            {
                Console.WriteLine("\n=== KÜTÜPHANE YÖNETİM SİSTEMİ ===");
                Console.WriteLine("1- Kitap Ekle         2- Kitapları Listele");
                Console.WriteLine("3- Üye Ekle           4- Kitap Ödünç Ver");
                Console.WriteLine("5- Kitap Teslim Al    6- Kitap Ara");
                Console.WriteLine("7- Üye Ara            8- Ödünç Geçmişi");
                Console.WriteLine("9- Kitap Sil          10- Üye Sil");
                Console.WriteLine("11- Üyeleri Listele   0- Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();// Kullanıcıdan seçim alınıyor
                if (secim == "0") break;// Çıkış seçeneği kontrol ediliyor

                switch (secim)//    Kullanıcının seçimine göre işlemler yapılıyor
                {
                    case "1":// Kitap ekleme işlemi
                        Console.Write("Kitap ID: "); int kid = int.Parse(Console.ReadLine());
                        Console.Write("Başlık: "); string baslik = Console.ReadLine();
                        Console.Write("Yazar: "); string yazar = Console.ReadLine();
                        Console.Write("ISBN: "); string isbn = Console.ReadLine();
                        yonetim.KitapEkle(new Kitap(kid, baslik, yazar, isbn));
                        Console.WriteLine("Kitap başarıyla eklendi.");
                        break;

                    case "2":// Kitapları listeleme işlemi
                        yonetim.KitaplariListele();
                        break;

                    case "3":// Üye ekleme işlemi
                        Console.Write("Üye ID: "); int uid = int.Parse(Console.ReadLine());
                        Console.Write("Ad Soyad: "); string adSoyad = Console.ReadLine();
                        Console.Write("Telefon: "); string tel = Console.ReadLine();
                        yonetim.UyeEkle(new Uye(uid, adSoyad, tel));
                        Console.WriteLine("Üye başarıyla eklendi.");
                        break;

                    case "4":// Kitap ödünç verme işlemi
                        Console.Write("Ödünç Alınacak Kitap ID: "); int oduncKid = int.Parse(Console.ReadLine());
                        Console.Write("Ödünç Alan Üye ID: "); int oduncUid = int.Parse(Console.ReadLine());
                        yonetim.KitapOduncVer(oduncKid, oduncUid);
                        break;

                    case "5":// Kitap teslim alma işlemi
                        Console.Write("Teslim Edilen Kitap ID: "); int teslimKid = int.Parse(Console.ReadLine());
                        yonetim.KitapTeslimAl(teslimKid);
                        break;

                    case "6":// Kitap arama işlemi
                        Console.Write("Aranacak Kitap Adı veya Yazarı: ");
                        string arananKitap = Console.ReadLine();
                        yonetim.KitapAra(arananKitap);
                        break;

                    case "7":// Üye arama işlemi
                        Console.Write("Aranacak Üye Adı: ");
                        string arananUye = Console.ReadLine();
                        yonetim.UyeAra(arananUye);
                        break;

                    case "8":// Ödünç geçmişi listeleme işlemi
                        yonetim.GecmisiListele();
                        break;

                    case "9":// Kitap silme işlemi
                        Console.Write("Silinecek Kitabın ISBN Numarası: ");
                        string silIsbn = Console.ReadLine();
                        yonetim.KitapSil(silIsbn);
                        break;

                    case "10":// Üye silme işlemi
                        Console.Write("Silinecek Üye ID: "); int silUid = int.Parse(Console.ReadLine());
                        yonetim.UyeSil(silUid);
                        break;

                    case "11":// Üyeleri listeleme işlemi
                        yonetim.UyeleriListele();
                        break;

                    default:// Geçersiz seçim işlemi
                        Console.WriteLine("Geçersiz seçim yaptınız, tekrar deneyin.");
                        break;
                }
            }
        }
    }
}
