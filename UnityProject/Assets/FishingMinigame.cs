using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class FishingMinigame : MonoBehaviour
{
    [Header("UI Elemanları")]
    [SerializeField] private GameObject fishingPanel;
    [SerializeField] private RectTransform targetBox;
    [SerializeField] private RectTransform playerIndicator;
    [SerializeField] private Image progressBarFill;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text titleText;

    [Header("Bar Ayarı")]
    [SerializeField] private float barHeight = 550f;

    // Player
    private float playerPos;
    private float playerVelocity;
    private float gravity = 800f;
    private float jumpForce = 700f;

    // Target
    private float targetPos;
    private float targetVelocity;
    private float targetTimer;
    private float targetIdleTimer;
    private bool targetIdle;

    // Progress
    private float progress;
    private float progressFillSpeed = 0.35f;
    private float progressDecaySpeed = 0.25f;   // dışındayken hızlı düşer

    // Zorluk
    private float targetMoveSpeed;
    private float targetMinWaitTime;
    private float targetMaxWaitTime;
    private float targetMinIdleTime;
    private float targetMaxIdleTime;

    private bool isHolding;
    private bool isPlaying;
    private bool resultShowing;
    private FishData currentFish;
    private UIManager uiManager;

    void Awake()
    {
        uiManager = FindFirstObjectByType<UIManager>();
        fishingPanel.SetActive(false);
    }

    public void StartMinigame(FishData fish)
    {
        currentFish = fish;
        fishingPanel.SetActive(true);

        targetMoveSpeed = Mathf.Lerp(150f, 350f, fish.difficulty);
        targetMinWaitTime = Mathf.Lerp(0.8f, 0.2f, fish.difficulty);
        targetMaxWaitTime = Mathf.Lerp(2.0f, 0.6f, fish.difficulty);
        targetMinIdleTime = Mathf.Lerp(0.5f, 0.1f, fish.difficulty);
        targetMaxIdleTime = Mathf.Lerp(1.5f, 0.3f, fish.difficulty);

        targetPos = barHeight / 2f;
        playerPos = barHeight / 2f;
        playerVelocity = 0f;
        targetVelocity = 0f;
        targetTimer = Random.Range(targetMinWaitTime, targetMaxWaitTime);
        targetIdle = false;
        progress = 0.5f;
        isPlaying = true;
        isHolding = false;
        resultShowing = false;

        titleText.text = fish.fishName + " kaçmaya çalışıyor!";
        resultText.text = "";
        resultText.gameObject.SetActive(false);

        UpdateUI();
    }

    void Update()
    {
        if (!isPlaying) return;

        MoveTarget();
        MovePlayer();
        UpdateProgress();
        UpdateUI();
        CheckResult();
    }

    void MoveTarget()
    {
        targetTimer -= Time.deltaTime;

        if (targetTimer <= 0f)
        {
            if (targetIdle)
            {
                // Idle bitti → yeni rastgele hedefe git
                targetIdle = false;
                float newTarget = Random.Range(
                    targetBox.sizeDelta.y / 2f,
                    barHeight - targetBox.sizeDelta.y / 2f
                );
                targetVelocity = (newTarget > targetPos ? 1f : -1f) * targetMoveSpeed;
                targetTimer = Random.Range(targetMinWaitTime, targetMaxWaitTime);
            }
            else
            {
                // Hareket bitti → idle'a geç
                targetIdle = true;
                targetVelocity = 0f;
                targetTimer = Random.Range(targetMinIdleTime, targetMaxIdleTime);
            }
        }

        targetPos += targetVelocity * Time.deltaTime;

        float halfTarget = targetBox.sizeDelta.y / 2f;
        if (targetPos < halfTarget)
        {
            targetPos = halfTarget;
            targetVelocity = Mathf.Abs(targetVelocity); // yukarı döndür
        }
        if (targetPos > barHeight - halfTarget)
        {
            targetPos = barHeight - halfTarget;
            targetVelocity = -Mathf.Abs(targetVelocity); // aşağı döndür
        }
    }

    void MovePlayer()
    {
        if (isHolding)
            playerVelocity += jumpForce * Time.deltaTime;
        else
            playerVelocity -= gravity * Time.deltaTime;

        playerVelocity = Mathf.Clamp(playerVelocity, -800f, 800f);
        playerPos += playerVelocity * Time.deltaTime;

        float halfPlayer = playerIndicator.sizeDelta.y / 2f;
        if (playerPos < halfPlayer)
        {
            playerPos = halfPlayer;
            playerVelocity = 0f;
        }
        if (playerPos > barHeight - halfPlayer)
        {
            playerPos = barHeight - halfPlayer;
            playerVelocity = 0f;
        }
    }

    void UpdateProgress()
    {
        float halfTarget = targetBox.sizeDelta.y / 2f;

        float targetBottom = targetPos - halfTarget;
        float targetTop = targetPos + halfTarget;

        // PlayerIndicator'ın merkezi TargetBox içinde mi
        bool isInside = playerPos >= targetBottom && playerPos <= targetTop;

        if (isInside)
        {
            progress += progressFillSpeed * Time.deltaTime;
            // Progress barı yeşil yap
            progressBarFill.color = Color.green;
        }
        else
        {
            progress -= progressDecaySpeed * Time.deltaTime;
            // Progress barı kırmızı yap
            progressBarFill.color = Color.red;
        }

        progress = Mathf.Clamp01(progress);
    }

    void UpdateUI()
    {
        float halfBar = barHeight / 2f;
        targetBox.anchoredPosition = new Vector2(0f, targetPos - halfBar);
        playerIndicator.anchoredPosition = new Vector2(0f, playerPos - halfBar);
        progressBarFill.fillAmount = progress;
    }

    void CheckResult()
    {
        if (resultShowing) return;

        if (progress >= 1f)
            StartCoroutine(ShowResult(true));
        else if (progress <= 0f)
            StartCoroutine(ShowResult(false));
    }

    IEnumerator ShowResult(bool caught)
    {
        isPlaying = false;
        resultShowing = true;
        resultText.gameObject.SetActive(true);

        if (caught)
        {
            resultText.text =  currentFish.fishName + " Yakalandı!";
            resultText.color = Color.green;
            currentFish.caught = true;
            uiManager?.OnFishCaught(currentFish);
        }
        else
        {
            resultText.text =  currentFish.fishName + " Kaçtı!";
            resultText.color = Color.red;
        }

        yield return new WaitForSeconds(2f);
        fishingPanel.SetActive(false);
        resultShowing = false;
    }

    public void OnHoldDown() => isHolding = true;
    public void OnHoldUp() => isHolding = false;
}