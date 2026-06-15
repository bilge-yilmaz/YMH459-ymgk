using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FishAlive;

public class PollutionEffectController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text pollutionInfoText;

    [Header("Speed Settings")]
    [SerializeField] private float pollutedAnimatorSpeed = 0.10f;
    [SerializeField] private float normalAnimatorSpeed = 1f;

    [Header("Color Settings")]
    [SerializeField] private Color pollutedColor = new Color(0.25f, 0.25f, 0.22f, 1f);

    private GameObject currentFishModel;
    private FishData currentFishData;
    private Animator[] animators;
    private FishMotion[] fishMotions;
    private Renderer[] renderers;
    private Dictionary<Material, Color> originalColors = new Dictionary<Material, Color>();

    public void SetCurrentFish(GameObject fishModel, FishData fishData)
    {
        currentFishModel = fishModel;
        currentFishData = fishData;

        if (currentFishModel == null) return;

        animators = currentFishModel.GetComponentsInChildren<Animator>(true);
        fishMotions = currentFishModel.GetComponentsInChildren<FishMotion>(true);
        renderers = currentFishModel.GetComponentsInChildren<Renderer>(true);
        SaveOriginalColorsOnce();
    }

    public void PolluteWater()
    {
        if (currentFishModel == null)
        {
            pollutionInfoText.text = "Önce bir balýk kartý taramalýsýn.";
            return;
        }

        foreach (Animator animator in animators)
            animator.speed = pollutedAnimatorSpeed;

        foreach (FishMotion motion in fishMotions)
        {
            motion.SetAutoMotion(false);
            motion.SetSpeed(0f);
            motion.SetMotionForce(0f);
        }

        ApplyPollutedColor();
        AudioManager.Instance?.PlayClip(currentFishData?.kirliSuSesi);
        pollutionInfoText.text = "Su kirlendiðinde balýk çok yavaþlar, rengi solar ve yaþam alaný zarar görür.";
    }

    public void CleanWater()
    {
        if (currentFishModel == null)
        {
            pollutionInfoText.text = "Önce bir balýk kartý taramalýsýn.";
            return;
        }

        foreach (Animator animator in animators)
            animator.speed = normalAnimatorSpeed;

        foreach (FishMotion motion in fishMotions)
            motion.SetAutoMotion(true);

        RestoreOriginalColors();
        AudioManager.Instance?.PlayClip(currentFishData?.temizSuSesi);
        pollutionInfoText.text = "Harika! Temiz su balýklarýn daha saðlýklý ve hareketli yaþamasýný saðlar.";
    }

    private void SaveOriginalColorsOnce()
    {
        foreach (Renderer renderer in renderers)
        {
            foreach (Material mat in renderer.materials)
            {
                if (!originalColors.ContainsKey(mat))
                {
                    if (mat.HasProperty("_BaseColor"))
                        originalColors.Add(mat, mat.GetColor("_BaseColor"));
                    else if (mat.HasProperty("_Color"))
                        originalColors.Add(mat, mat.GetColor("_Color"));
                }
            }
        }
    }

    private void ApplyPollutedColor()
    {
        foreach (Renderer renderer in renderers)
        {
            foreach (Material mat in renderer.materials)
            {
                if (mat.HasProperty("_BaseColor"))
                    mat.SetColor("_BaseColor", pollutedColor);
                if (mat.HasProperty("_Color"))
                    mat.SetColor("_Color", pollutedColor);
            }
        }
    }

    private void RestoreOriginalColors()
    {
        foreach (var item in originalColors)
        {
            Material mat = item.Key;
            Color originalColor = item.Value;
            if (mat == null) continue;

            if (mat.HasProperty("_BaseColor"))
                mat.SetColor("_BaseColor", originalColor);
            if (mat.HasProperty("_Color"))
                mat.SetColor("_Color", originalColor);
        }
    }
}