using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using FishAlive;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ARImageModelSpawner : MonoBehaviour
{
    [SerializeField] private FishData[] fishes;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private PollutionEffectController pollutionEffectController;

    private ARTrackedImageManager trackedImageManager;
    private Dictionary<string, GameObject> spawnedModels = new Dictionary<string, GameObject>();
    private Dictionary<string, TrackingState> lastTrackingStates = new Dictionary<string, TrackingState>();
    private string currentlyTrackingFish = null;

    void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        trackedImageManager.trackablesChanged.AddListener(OnTrackablesChanged);
    }

    void OnDisable()
    {
        trackedImageManager.trackablesChanged.RemoveListener(OnTrackablesChanged);
    }

    void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
            UpdateImage(trackedImage);

        foreach (var trackedImage in eventArgs.updated)
            UpdateImage(trackedImage);
    }

    void UpdateImage(ARTrackedImage trackedImage)
    {
        FishData fish = FindFishByTargetName(trackedImage.referenceImage.name);
        if (fish == null) return;

        string key = fish.targetImageName;
        TrackingState currentState = trackedImage.trackingState;
        TrackingState previousState = lastTrackingStates.ContainsKey(key)
            ? lastTrackingStates[key]
            : TrackingState.None;

        if (currentState == previousState) return;

        lastTrackingStates[key] = currentState;

        if (currentState == TrackingState.Tracking)
        {
            if (currentlyTrackingFish != null && currentlyTrackingFish != key)
            {
                HideFish(currentlyTrackingFish);
                lastTrackingStates[currentlyTrackingFish] = TrackingState.None;
            }

            currentlyTrackingFish = key;

            GameObject model;
            if (!spawnedModels.ContainsKey(key))
            {
                model = Instantiate(fish.fishPrefab, trackedImage.transform);
                spawnedModels.Add(key, model);
            }
            else
            {
                model = spawnedModels[key];
                model.transform.SetParent(trackedImage.transform);
            }

            model.SetActive(true);
            model.transform.localPosition = new Vector3(0f, 0.05f, 0f);
            model.transform.localRotation = Quaternion.identity;

            // ✅ Balığı kart etrafında sınırla
            FishMotion[] motions = model.GetComponentsInChildren<FishMotion>(true);
            foreach (FishMotion motion in motions)
            {
                Vector3 center = model.transform.position;
                Vector3 limitSize = new Vector3(0.1f, 0.05f, 0.1f);
                motion.EnableHardLimits(center - limitSize, center + limitSize);
            }

            if (pollutionEffectController != null)
                pollutionEffectController.SetCurrentFish(model, fish);

            if (uiManager != null)
                uiManager.OnFishDetected(fish);
        }
        else
        {
            if (currentlyTrackingFish == key)
                currentlyTrackingFish = null;

            HideFish(key);
        }
    }

    FishData FindFishByTargetName(string targetName)
    {
        foreach (FishData fish in fishes)
        {
            if (fish.targetImageName == targetName)
                return fish;
        }
        return null;
    }

    void HideFish(string targetName)
    {
        if (spawnedModels.ContainsKey(targetName))
            spawnedModels[targetName].SetActive(false);

        if (uiManager != null)
            uiManager.OnFishLost();
    }

    public FishData[] GetFishes()
    {
        return fishes;
    }
}