using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ARImageModelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject modelPrefab;
    [SerializeField] private string targetImageName;
    [SerializeField] private FishInfoUIController uiController;

    private ARTrackedImageManager trackedImageManager;
    private GameObject spawnedModel;

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
        {
            UpdateImage(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            if (spawnedModel != null)
            {
                spawnedModel.SetActive(false);
            }

            if (uiController != null)
            {
                uiController.HideInfoButton();
            }
        }
    }

    void UpdateImage(ARTrackedImage trackedImage)
    {
        if (trackedImage.referenceImage.name != targetImageName)
            return;

        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            if (spawnedModel == null)
            {
                spawnedModel = Instantiate(modelPrefab, trackedImage.transform);
            }

            spawnedModel.SetActive(true);
            spawnedModel.transform.localPosition = new Vector3(0f, 0.05f, 0f);
            spawnedModel.transform.localRotation = Quaternion.identity;
            

            if (uiController != null)
            {
                uiController.ShowInfoButton();
            }
        }
        else
        {
            if (spawnedModel != null)
            {
                spawnedModel.SetActive(false);
            }

            if (uiController != null)
            {
                uiController.HideInfoButton();
            }
        }
    }
}