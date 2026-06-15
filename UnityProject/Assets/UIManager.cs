using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject arHudPanel;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject collectionPanel;
    [SerializeField] private GameObject pollutionPanel;

    [Header("Texts")]
    [SerializeField] private TMP_Text missionText;
    [SerializeField] private TMP_Text fishNameText;
    [SerializeField] private TMP_Text fishDescriptionText;
    [SerializeField] private TMP_Text starText;

    [Header("Collection")]
    [SerializeField] private TMP_Text[] collectionCardTexts;

    [Header("Fishing")]
    [SerializeField] private FishingMinigame fishingMinigame;
    [SerializeField] private Button catchButton;

    private int starCount = 0;
    private bool isExploring = false;
    private FishData lastDetectedFish;

    void Start()
    {
        mainMenuPanel.SetActive(true);
        arHudPanel.SetActive(false);
        infoPanel.SetActive(false);
        collectionPanel.SetActive(false);
        pollutionPanel.SetActive(false);
        missionText.text = "Görev: Balık kartını tara!";
        starText.text = "Yıldız: 0";
        if (catchButton != null)
            catchButton.interactable = false;
        UpdateCollectionUI();
    }

    public void StartExplore()
    {
        isExploring = true;
        mainMenuPanel.SetActive(false);
        arHudPanel.SetActive(true);
        infoPanel.SetActive(false);
        collectionPanel.SetActive(false);
        pollutionPanel.SetActive(false);
        missionText.text = "Görev: Balık kartını tara!";
    }

    public void BackToMainMenu()
    {
        isExploring = false;
        mainMenuPanel.SetActive(true);
        arHudPanel.SetActive(false);
        infoPanel.SetActive(false);
        collectionPanel.SetActive(false);
        pollutionPanel.SetActive(false);
        AudioManager.Instance?.StopAudio();
    }

    public void OnFishDetected(FishData fish)
    {
        if (!isExploring) return;

        lastDetectedFish = fish;
        fishNameText.text = fish.fishName;
        fishDescriptionText.text = fish.description;

        AudioManager.Instance?.PlayClip(fish.bilgiSesi);

        if (catchButton != null)
            catchButton.interactable = true;

        if (!fish.discovered)
        {
            fish.discovered = true;
            starCount++;
            missionText.text = "Harika! " + fish.fishName + " keşfedildi.";
            starText.text = "Yıldız: " + starCount;
        }
        else
        {
            missionText.text = fish.fishName + " bulundu!";
        }

        UpdateCollectionUI();
    }

    public void OnFishLost()
    {
        lastDetectedFish = null;
        if (catchButton != null)
            catchButton.interactable = false;
        AudioManager.Instance?.StopAudio();
    }

    public void OnCatchButtonPressed()
    {
        if (lastDetectedFish == null) return;
        fishingMinigame.StartMinigame(lastDetectedFish);
    }

    public void OnFishCaught(FishData fish)
    {
        starCount++;
        starText.text = "Yıldız: " + starCount;
        missionText.text = fish.fishName + " yakalandı! +1 ⭐";
        UpdateCollectionUI();
    }

    public void OpenInfoPanel() => infoPanel.SetActive(true);
    public void CloseInfoPanel() => infoPanel.SetActive(false);

    public void OpenCollectionPanel()
    {
        UpdateCollectionUI();
        collectionPanel.SetActive(true);
    }

    public void CloseCollectionPanel() => collectionPanel.SetActive(false);
    public void OpenPollutionPanel() => pollutionPanel.SetActive(true);
    public void ClosePollutionPanel() => pollutionPanel.SetActive(false);

    private void UpdateCollectionUI()
    {
        ARImageModelSpawner spawner = FindFirstObjectByType<ARImageModelSpawner>();
        if (spawner == null) return;

        FishData[] fishes = spawner.GetFishes();
        for (int i = 0; i < collectionCardTexts.Length && i < fishes.Length; i++)
        {
            collectionCardTexts[i].text = fishes[i].discovered
                ? "[KEŞFEDİLDİ] " + fishes[i].fishName
                : "[KİLİTLİ] " + fishes[i].fishName;
        }
    }
}