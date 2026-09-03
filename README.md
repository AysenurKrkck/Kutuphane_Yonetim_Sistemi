# 📚 Kütüphane Yönetim Sistemi (Library Management System)

Gerçek bir kütüphane ekosisteminin temel çalışma mantığını modelleyen, **Nesne Yönelimli Programlama (OOP)** prensipleri ve ilişkisel veri yönetimi odaklı geliştirilmiş bir C# konsol uygulaması.

---

## 🎯 Projenin Amacı

Bu projenin temel hedefi; gerçek hayattaki varlıkları (Kitap, Üye, İşlem) ve aralarındaki dinamik ilişkileri analiz edip, doğru sınıflar (classes) ve sorumluluk ayrımları (Separation of Concerns) kullanarak yazılım mimarisine aktarmayı simüle etmektir.

---

## 🚀 Özellikler

Uygulama, temel bir kütüphane akışını yönetmek üzere **11 temel işlev** barındırır:

1. **Kitap Ekleme:** Kütüphane envanterine yeni kitap kaydı oluşturma.
2. **Kitap Listeleme:** Mevcut tüm kitapların rafta veya ödünçte olma durumunu anlık görüntüleme.
3. **Üye Ekleme:** Sisteme yeni okuyucu/üye tanımlama.
4. **Kitap Ödünç Alma:** Kitap uygunluğunu kontrol ederek üyeye zimmetleme ve işlem kaydı açma.
5. **Kitap Teslim Etme:** Aktif ödünç kaydını kapatıp kitabın durumunu yeniden "Rafta" olarak güncelleme.
6. **Gecikme Cezası Hesaplama:** 14 günlük standart ödünç süresini aşan teslimatlarda gün bazlı ceza tutarı hesaplama.
7. **Kitap Arama:** Başlık veya yazar adına göre büyük/küçük harf duyarsız dinamik arama.
8. **Üye Arama:** İsim ve soyisme göre üye sorgulama.
9. **Ödünç Geçmişi:** Hem aktif hem de tamamlanmış tüm işlemleri ceza ve tarih detaylarıyla listeleme.
10. **Güvenli Silme (Validation):** 
    - Ödünçte olan bir kitabın silinmesini engelleme.
    - Elinde teslim edilmemiş kitap bulunan bir üyenin silinmesini engelleme.
11. **Üyeleri Listeleme:** Kayıtlı üyeleri ve her üyenin anlık olarak elinde bulundurduğu aktif teslim edilmemiş kitap sayısını listeleme.
---

## 🏗️ Mimari ve OOP Modellemesi

Proje, nesneler arası bağımlılıkları ve veri bütünlüğünü korumak adına varlıklar (entities) ve işlemler arasında ara modelleme kullanır:
- **`Kitap`:** Kitabın kimlik, künye ve anlık ödünç durumunu tutar.
- **`Uye`:** Sisteme kayıtlı kullanıcıların iletişim ve temel bilgilerini barındırır.
- **`OduncIslemi` (Association/Transaction Entity):** Kitap ve üye arasındaki ilişkiyi doğrudan bağlamak yerine bu sınıf üzerinden yönetir. Alış tarihi, teslim tarihi (`DateTime?`) ve ceza durumunu saklayarak işlem geçmişini izlenebilir kılar.
- **`Kutuphane`:** Tüm listeleri yöneten, arama, iş kuralları (validation) ve ceza hesaplama mantığını içeren ana yönetim sınıfı.

---

## 🛠️ Kullanılan Teknolojiler

- **Dil:** C# (.NET Core / .NET Framework uyumlu)
- **Paradigma:** Nesne Yönelimli Programlama (OOP)
- **Veri Yapıları & Sorgulama:** Generic Collections (`List<T>`), LINQ (`Where`, `FirstOrDefault`, `Any`, `Count`)

---

## Örnek Menü Arayüzü
```text
=== KÜTÜPHANE YÖNETİM SİSTEMİ ===
1- Kitap Ekle         2- Kitapları Listele
3- Üye Ekle           4- Kitap Ödünç Ver
5- Kitap Teslim Al    6- Kitap Ara
7- Üye Ara            8- Ödünç Geçmişi
9- Kitap Sil          10- Üye Sil
11- Üyeleri Listele   0- Çıkış
```
---
## 📜 Lisans

Bu proje [MIT](LICENSE) lisansı ile lisanslanmıştır.
---
