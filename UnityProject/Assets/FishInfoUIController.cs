using UnityEngine;
using TMPro;

public class FishInfoUIController : MonoBehaviour
{
    [SerializeField] private GameObject infoButton;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TMP_Text fishNameText;
    [SerializeField] private TMP_Text fishDescriptionText;

    [SerializeField] private string fishName = "Guppy Baligi";

    [TextArea]
    [SerializeField] private string fishDescription = "Tatli suda yasayan kucuk ve renkli bir baliktir.";

    void Start()
    {
        infoButton.SetActive(false);
        infoPanel.SetActive(false);
    }

    public void ShowInfoButton()
    {
        infoButton.SetActive(true);
    }

    public void HideInfoButton()
    {
        infoButton.SetActive(false);
        infoPanel.SetActive(false);
    }

    public void OpenInfoPanel()
    {
        fishNameText.text = fishName;
        fishDescriptionText.text = fishDescription;
        infoPanel.SetActive(true);
    }

    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
    }
}