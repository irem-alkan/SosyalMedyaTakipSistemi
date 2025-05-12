# Proje Raporu: Sosyal Medya İçin Eşsiz Kullanıcı Takip Sistemi

**GitHub Linki:**  
https://github.com/irem-alkan/SosyalMedyaTakipSistemi

**Grup Üyeleri:**  
- Şaziye İrem ALKAN – 032290032  
- Ali TURHAN – 032290025

---

## 📌 Projenin Amacı ve Kapsamı

Bu projenin amacı, bir sosyal medya platformunda kullanıcıların takip ettikleri kişileri ayrık küme yapısı ile yönetmek, ortak takipçileri analiz etmek ve son gezilen profiller ile takip öneri sistemini gerçekleştirerek kullanıcı etkileşimini incelemektir.

Proje, sabit veriler ile ASP.NET Core MVC mimarisi kullanılarak geliştirilmiştir.

---

## Kullanılan Veri Yapıları ve Amaçları

### 1. `Dictionary<string, HashSet>` – Ana Veri Yapısı
- **Amaç:** Her kullanıcının takip ettiği kişileri saklamak.
- **Faydaları:**
  - Anahtar-değer (key-value) yapısı sayesinde hızlı erişim (O(1))
  - HashSet ile birlikte kullanıldığında küme işlemleri kolaylaşır
  - Takip verisinin yönetilmesini sağlar

### 2. `HashSet` – Küme İşlemleri
- **Amaç:** Kullanıcıların takip ettikleri kişileri tekrarsız olarak tutmak.
- **Avantajları:**
  - Küme işlemleri için çok verimli
  - LINQ ile `Union`, `Intersect`, `Except` işlemleri uygulandı
- **Karmaşıklık Analizi:**
  - Array kullanılsaydı O(n)
  - HashSet ile arama/ekleme/silme: O(1)

### 3. `Queue` – Son Ziyaret Edilen Kullanıcılar
- **Amaç:** Kullanıcının son görüntülediği profilleri sırayla tutmak (FIFO).
- **Faydaları:**
  - Son 5 ziyaret edilen profili saklayarak gezinti takibi yapılır
  - Karmaşıklık: Enqueue/Dequeue işlemleri O(1)
  - Dictionary<string, Queue<string>> ile kullanıcıya özel ziyaret geçmişi

### 4. `LinkedList` – Takip Önerileri Listesi
- **Amaç:** Takip edilmeyen ama diğer kullanıcıların takip ettiği kişileri öneri olarak sunmak.
- **Avantajları:**
  - Listenin başından/sonundan kolay ekleme/silme
  - Dinamik yapı sayesinde öneriler kolayca güncellenebilir
  - Karmaşıklık: O(1) başa/sona ekleme ve silme

---

## Algoritma Karşılaştırması

| Veri Yapısı   | Arama | Ekleme | Silme | Kullanım Alanı           |
|---------------|--------|--------|--------|---------------------------|
| Array         | O(n)   | O(n)   | O(n)   | Sabit uzunlukta veriler  |
| LinkedList    | O(n)   | O(1)   | O(1)   | Öneri listeleri          |
| Queue         | O(1)   | O(1)   | O(1)   | Ziyaret listesi          |
| HashSet       | O(1)   | O(1)   | O(1)   | Küme işlemleri           |

---

## ✨ Geliştirilen Özellikler

- **Kullanıcı Ekleme:** Yeni kullanıcılar sisteme eklenebilir. Takip listeleri baştan tanımlanabilir.
- **Kullanıcı Karşılaştırma:** İki kullanıcı arasında ortak takip ettikleri kişiler, farkları ve birleşimi gösterilir.
- **Takip Öneri Sistemi:** Kullanıcının takip etmediği ama diğerlerinin takip ettiği kişiler öneri olarak sunulur.
- **Ziyaret Geçmişi:** Her kullanıcı son gezdiği 5 profili sırasıyla görebilir.
- **Dashboard (Kullanıcı Paneli):** Her kullanıcıya özel ekran. Takip ettikleri, takipçileri, ziyaret geçmişi ve önerileri özel olarak gösterir.
- **Popüler Kullanıcılar Sayfası:** En çok takip edilen 10 kullanıcı listelenir ve takipçi sayıları gösterilir.
- **Kullanıcı Arama (Filtreleme):** Tüm kullanıcılar içerisinde arama yapılabilir.
- **Dark Mode Geçişi:** Tema bir butonla karanlık mod ve açık mod arasında geçiş yapabilir. Seçim tarayıcıda kaydedilir.
- **Modern Arayüz:** Bootstrap 5 ve Bootstrap Icons kullanılarak kart, tablo ve form yapıları modernleştirildi. Responsive tasarıma uygundur.

---

## ✅ Sonuç

Bu proje, sosyal medya kullanıcılarının takip ilişkilerini analiz etmek, öneri sunmak ve son ziyaretleri kaydetmek gibi temel işlevleri, dört temel veri yapısıyla (Dictionary, HashSet, Queue, LinkedList) başarıyla gerçekleştirmiştir.

Seçilen veri yapıları, sistemin hızlı çalışmasını ve dinamik içerik üretmesini sağlamış; küme işlemleri, geçmiş takibi ve öneri algoritmaları verimli biçimde uygulanmıştır. MVC mimarisiyle geliştirilen proje, modern arayüzü, dark mode özelliği ve kullanıcıya özel dashboard ile hem teknik hem görsel açıdan zenginleştirilmiştir.

Sonuç olarak, bu proje hem veri yapılarının gerçek dünya senaryolarında nasıl etkili kullanılabileceğini göstermiş hem de yazılım geliştirme süreçlerine bütünsel bir yaklaşım sunmuştur.
