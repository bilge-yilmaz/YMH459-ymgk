# 🐟 Fırat'ın Derinlikleri

> Fırat Nehri'nin derinliklerini artırılmış gerçeklik ile keşfet!

![Unity](https://img.shields.io/badge/Unity-6000.0.41f1-black?style=for-the-badge&logo=unity)
![Platform](https://img.shields.io/badge/Platform-Android-green?style=for-the-badge&logo=android)
![AR](https://img.shields.io/badge/AR-Foundation-blue?style=for-the-badge)

## Ekip Üyeleri

Merve Aslan - 210541035
Semra Ersoy - 220541103
Bilge Yılmaz - 220541031


Fırat'ın Derinlikleri, artırılmış gerçeklik (AR) teknolojisi kullanılarak geliştirilmiş eğitici bir mobil uygulamadır. Kullanıcılar balık kartlarını kameraya tutarak Fırat Nehri'nde yaşayan balıkları keşfedebilir, su kirliliğinin etkilerini gözlemleyebilir ve balık yakalama mini oyunu oynayabilir.

---

## 📋 İçindekiler

- [Özellikler](#-özellikler)
- [Gereksinimler](#-gereksinimler)
- [Kurulum](#-kurulum)
- [Build Alma](#-android-build-alma)
- [Balıklar](#-balıklar)
- [Proje Yapısı](#-proje-yapısı)
- [Kullanılan Teknolojiler](#️-kullanılan-teknolojiler)
- [Önemli Notlar](#-önemli-notlar)

---

## 🎮 Özellikler

### 🔭 AR Balık Keşfi
- Balık kartlarını kameraya tutarak 3D balık modellerini gerçek dünyada gör
- Her balık hakkında detaylı bilgi al
- Yeni balık keşfettikçe yıldız kazan

### 🎣 Balık Yakalama Mini Oyunu
- Stardew Valley tarzı balık yakalama mekaniği
- Göstergeyi yeşil kutuda tutarak balığı yakala
- Her balığın farklı zorluk seviyesi vardır

### 💧 Su Kirliliği Simülasyonu
- Kirlet butonuna basarak su kirliliğinin balığa etkisini gözlemle
- Balığın rengi solar, hareketi yavaşlar
- Temizle butonuyla balığı kurtar

### 📚 Koleksiyon Sistemi
- Keşfedilen balıklar koleksiyona eklenir
- Tüm balıkları keşfetmeye çalış

### ❓ Nasıl Oynanır Rehberi
- Uygulama içi adım adım rehber
- Çocuklara yönelik sade ve anlaşılır anlatım

---

## 📋 Gereksinimler

| Gereksinim | Versiyon |
|---|---|
| Unity | 6000.0.41f1 (Unity 6) |
| Minimum Android | Android 7.0 (API 24) |
| Hedef Android | Android 14 |

### Gerekli Unity Paketleri
- AR Foundation
- ARCore XR Plugin
- TextMeshPro

### Cihaz Gereksinimleri
- ARCore destekli Android telefon veya tablet
- Çalışan arka kamera
- İyi aydınlatılmış ortam

---

## 🚀 Kurulum

### Depoyu Klonla

```bash
git clone https://github.com/kullanici-adi/firat-in-derinlikleri.git
```

### Unity'de Aç

1. **Unity Hub**'ı aç
2. **Add** butonuna bas
3. Klonlanan klasörü seç
4. **Unity 6 (6000.0.41f1)** ile aç
5. Proje yüklenince `Assets/Scenes/SampleScene` sahnesini aç

### Gerekli Paketleri Kontrol Et

1. **Window → Package Manager** aç
2. Şu paketlerin yüklü olduğunu kontrol et:

```
✅ AR Foundation
✅ ARCore XR Plugin  
✅ TextMeshPro
```

---

## 📱 Android Build Alma

1. **File → Build Settings** aç
2. Platform olarak **Android** seç → **Switch Platform** bas
3. **Player Settings** aç ve şu ayarları yap:

```
Company Name    → [Şirket Adı]
Product Name    → Fırat'ın Derinlikleri
Minimum API     → Android 7.0 (API 24)
Target API      → Android 14
Graphics API    → OpenGLES3
```

4. **Build and Run** ile APK oluştur
5. APK'yı AR destekli Android cihaza yükle

---

## 🐠 Balıklar

| Balık | Zorluk | Açıklama |
|---|---|---|
| 🐟 Guppy Balığı | ⭐ Kolay | Küçük ve hareketli |
| 🤡 Palyaço Balığı | ⭐⭐ Orta | Renkli ve neşeli |
| 🐋 Ton Balığı | ⭐⭐⭐ Zor | Büyük ve hızlı |
| 🐟 Yayın Balığı | ⭐⭐ Orta | Fırat'ın devi |
| 🐟 Turna Balığı | ⭐⭐⭐ Zor | Avcı ruhlu |
| 🐟 Sazan Balığı | ⭐ Kolay | Fırat'ın kadim sakini |
| 🎏 Koi Balığı | ⭐⭐ Orta | Renkli misafir |

---

## 📁 Proje Yapısı

```
Assets/
├── 📁 Scenes/              → Unity sahneleri
│   └── SampleScene
├── 📁 Scripts/             → C# scriptleri
│   ├── ARImageModelSpawner.cs
│   ├── AudioManager.cs
│   ├── FishData.cs
│   ├── FishingMinigame.cs
│   ├── HowToPlayController.cs
│   ├── PollutionEffectController.cs
│   ├── SimpleSwim.cs
│   └── UIManager.cs
├── 📁 Prefabs/             → Balık prefabları
├── 📁 Sounds/              → Ses dosyaları
├── 📁 Textures/            → Görseller
├── 📁 Materials/           → Materyaller
└── 📁 Resources/           → AR referans görselleri
```

---

## 🛠️ Kullanılan Teknolojiler

| Teknoloji | Kullanım Amacı |
|---|---|
| Unity 6 | Oyun motoru |
| AR Foundation | Artırılmış gerçeklik altyapısı |
| ARCore | Android AR desteği |
| FishAlive Asset | Balık animasyon sistemi |
| TextMeshPro | UI metin sistemi |

---

## ⚠️ Önemli Notlar

> **Dikkat:** Uygulama yalnızca **ARCore destekli** Android cihazlarda çalışır.

- İyi aydınlatılmış ortamda kullanılması önerilir
- Balık kartları **fiziksel olarak basılı** olmalıdır
- ARCore yüklü olmayan cihazlarda uygulama açılmayabilir
- iOS desteği henüz test edilmemiştir

---

## 📄 Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

---

<div align="center">
  <p>🐟 Fırat'ın Derinliklerini Keşfet! 🐟</p>
</div>
