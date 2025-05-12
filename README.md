Proje Raporu: Sosyal Medya İçin Eşsiz Kullanıcı Takip Sistemi

github link:
https://github.com/irem-alkan/SosyalMedyaTakipSistemi

Grup Üyeleri:
Şaziye İrem ALKAN 032290032

 Projenin Amacı ve Kapsamı
Bu projenin amacı, bir sosyal medya platformunda kullanıcıların takip ettikleri kişileri ayrık küme yapısı ile yönetmek, ortak takipçileri analiz etmek ve son gezilen profiller ile takip öneri sistemini gerçekleştirerek kullanıcı etkileşimini incelemektir. 
Proje, sabit veriler ile ASP.NET Core MVC mimarisi kullanılarak geliştirilmiştir.

 Kullanılan Veri Yapıları ve Amaçları
 
1. Dictionary<string, HashSet>  (Ana Veri Yapısı)
Amaç: Her kullanıcının takip ettiği kişileri saklamak.
Faydaları:
Anahtar-değer (key-value) yapısı sayesinde hızlı erişim (O(1)).
HashSet ile birlikte kullanıldığında kesif küme işlemleri desteklenir.
Takip verisinin yönetilmesini sağlar.

2. HashSet  (Küme İşlemleri)
Amaç: Kullanıcıların takip ettikleri kişileri tekrarsız olarak tutmak.
Avantajları:
Küme işlemleri için çok verimli.
Union, Intersect, Except LINQ fonksiyonları kullanıldı.
Karmaşıklık Analizi:
Dizi (string[]) kullansaydık O(n) olurdu.
HashSet ile arama/ekleme/silme: O(1)

3. Queue  (Son Ziyaret Edilen Kullanıcılar)
Amaç: Kullanıcının son görüntülemiş olduğu profilleri sırayla tutmak (FIFO).
Faydaları:
Son 5 ziyaret edilen profili saklayarak gezinti takibi yapılır.
Karmaşıklık: Enqueue/Dequeue işlemleri O(1).
Bağlantı: Dictionary<string, Queue<string>> yapısı ile her kullanıcıya özel liste tutuldu.

4. LinkedList  (Takip Önerileri Listesi)
Amaç: Kullanıcıya, takip etmediği ama başka bir kullanıcının takip ettiği kişilerden öneri vermek.
Avantajları:
Listenin başından/sonundan kolay ekleme/silme.
Dinamik yapı sayesinde yeni öneriler kolayca eklenebilir.
Karmaşıklık: O(1) başa/sona ekleme ve silme.

Algoritma Karşılaştırması
               Arama  Ekleme Silme
Array           O(n)   O(n)  O(n)  Sabit uzunlukta veriler
LinkedList      O(n)   O(1)  O(1)  Öneri listeleri
Queue           O(1)   O(1)  O(1)  Ziyaret listesi
HashSet         O(1)   O(1)  O(1)  Küme işlemleri


Sonuç
Bu proje, sosyal medya ortamında kullanıcı takibi ve topluluk etkileşimlerinin veri yapıları aracılığıyla analiz edilmesini hedeflemiştir.
Kullanılan 4 temel veri yapısı sadece kriteri karşılamak için değil, mantıklı ve bağlantılı şekilde sistem içine entegre edildi. 
Geliştirilen sistem MVC mimarisine uygun şekilde yapılandırıldı, dinamik olarak takip önerileri ve son gezilen profiller özellikleri kazandırıldı.

