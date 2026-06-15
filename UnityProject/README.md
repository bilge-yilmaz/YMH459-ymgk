🐟 Fırat'ın Derinlikleri
Fırat'ın Derinlikleri, artırılmış gerçeklik (AR) teknolojisi kullanılarak geliştirilmiş eğitici bir mobil uygulamadır. Kullanıcılar balık kartlarını kameraya tutarak Fırat Nehri'nde yaşayan balıkları keşfedebilir, su kirliliğinin etkilerini gözlemleyebilir ve balık yakalama mini oyunu oynayabilir.

📋 Gereksinimler

Unity: 6000.0.41f1 (Unity 6)
Platform: Android (ARCore destekli cihaz gereklidir)
Minimum Android Versiyon: Android 7.0 (API 24)
Cihaz: AR destekli kameraya sahip Android telefon veya tablet
Paketler:

AR Foundation
ARCore XR Plugin
TextMeshPro




🚀 Kurulum
Unity'de Açma

Unity Hub'ı aç
Add butonuna bas
Projenin klasörünü seç
Unity 6 (6000.0.41f1) ile aç
Proje yüklenince Assets/Scenes/SampleScene sahnesini aç

Gerekli Paketleri Yükle

Window → Package Manager aç
Şu paketlerin yüklü olduğunu kontrol et:

AR Foundation
ARCore XR Plugin
TextMeshPro




📱 Android Build Alma

File → Build Settings aç
Platform olarak Android seç
Switch Platform bas
Player Settings aç:

Company Name ve Product Name doldur
Minimum API Level: Android 7.0
Target API Level: Android 14
Graphics API: OpenGLES3


Build and Run ile APK oluştur
APK'yı AR destekli Android cihaza yükle


🎮 Özellikler
AR Balık Keşfi

Balık kartlarını kameraya tutarak 3D balık modellerini gerçek dünyada gör
Her balık hakkında bilgi al
Yeni balık keşfettikçe yıldız kazan

Balık Yakalama Mini Oyunu

Stardew Valley tarzı balık yakalama mekaniği
Göstergeyi yeşil kutuda tutarak balığı yakala
Her balığın zorluk seviyesi farklıdır

Su Kirliliği Simülasyonu

Kirlet butonuna basarak su kirliliğinin balığa etkisini gör
Balığın rengi solar, hareketi yavaşlar
Temizle butonuyla balığı kurtar

Koleksiyon Sistemi

Keşfedilen balıklar koleksiyona eklenir
Tüm balıkları keşfetmeye çalış

Nasıl Oynanır Rehberi

Uygulama içi adım adım rehber
Çocuklara yönelik sade anlatım


🐠 Balıklar
BalıkZorlukGuppy BalığıKolayPalyaço BalığıOrtaTon BalığıZorYayın BalığıOrtaTurna BalığıZorSazan BalığıKolayKoi BalığıOrta

🛠️ Kullanılan Teknolojiler

Unity 6 — Oyun motoru
AR Foundation — Artırılmış gerçeklik altyapısı
ARCore — Android AR desteği
FishAlive Asset — Balık animasyon sistemi
TextMeshPro — UI metin sistemi


📁 Proje Yapısı
Assets/
├── Scenes/          → Unity sahneleri
├── Scripts/         → C# scriptleri
├── Prefabs/         → Balık prefabları
├── Sounds/          → Ses dosyaları
├── Textures/        → Görseller
├── Materials/       → Materyaller
└── Resources/       → AR referans görselleri

⚠️ Önemli Notlar

Uygulama sadece AR destekli cihazlarda çalışır
İyi aydınlatılmış ortamda kullanılması önerilir
Balık kartları fiziksel olarak basılı olmalıdır
ARCore yüklü olmayan cihazlarda uygulama açılmayabilir
