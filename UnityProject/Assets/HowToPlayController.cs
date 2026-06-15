using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HowToPlayController : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject howToPlayPanel;

    [Header("Sayfa Elemanları")]
    [SerializeField] private Image pageIcon;
    [SerializeField] private TMP_Text pageTitle;
    [SerializeField] private TMP_Text pageDesc;

    [Header("Dot Göstergeleri")]
    [SerializeField] private Image[] dots;

    [Header("Opsiyonel İkonlar")]
    [SerializeField] private Sprite[] pageIcons;

    [Header("Renkler")]
    [SerializeField] private Color activeDotColor = new Color(1f, 0.85f, 0f, 1f);
    [SerializeField] private Color inactiveDotColor = new Color(1f, 1f, 1f, 0.3f);

    private int currentPage = 0;

    private readonly string[] titles = new string[]
    {
        "Balığı Keşfet!",
        "Yıldız Kazan!",
        "Balık Yakala!",
        "Suyu Koru!"
    };

    private readonly string[] descriptions = new string[]
    {
        "Balık kartını kameraya tut.\nBalık canlanacak ve\nsana bilgi verecek!",
        "Her yeni balık keşfettiğinde\nbir yıldız kazanırsın.\nTüm balıkları bul!",
        "Balığı gördüğünde Yakala\nbutonuna bas. Göstergeyi\nyeşil kutuda tut ve yakala!",
        "Kirlet butonuna basarsan\nbalık hastalanır.\nTemizle butonuyla onu kurtar!"
    };

    void Awake()
    {
        howToPlayPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        currentPage = 0;
        howToPlayPanel.SetActive(true);
        ShowPage(0);
    }

    public void ClosePanel()
    {
        howToPlayPanel.SetActive(false);
        // Ana menüyü aç
        UIManager uiManager = FindFirstObjectByType<UIManager>();
        uiManager?.BackToMainMenu();
    }

    public void NextPage()
    {
        if (currentPage < titles.Length - 1)
        {
            currentPage++;
            ShowPage(currentPage);
        }
        else
        {
            ClosePanel();
        }
    }

    public void PrevPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            ShowPage(currentPage);
        }
    }

    void ShowPage(int index)
    {
        pageTitle.text = titles[index];
        pageDesc.text = descriptions[index];

        // İkon varsa göster
        if (pageIcon != null && pageIcons != null &&
            index < pageIcons.Length && pageIcons[index] != null)
        {
            pageIcon.sprite = pageIcons[index];
            pageIcon.enabled = true;
        }
        else if (pageIcon != null)
        {
            pageIcon.enabled = false;
        }

        // Dotları güncelle
        if (dots != null)
        {
            for (int i = 0; i < dots.Length; i++)
            {
                if (dots[i] != null)
                    dots[i].color = (i == index) ? activeDotColor : inactiveDotColor;
            }
        }
    }
}