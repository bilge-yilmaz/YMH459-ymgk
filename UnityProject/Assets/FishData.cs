using UnityEngine;

[System.Serializable]
public class FishData
{
    public string targetImageName;
    public string fishName;
    [TextArea]
    public string description;
    public GameObject fishPrefab;

    [Header("Ses Dosyalarý")]
    public AudioClip bilgiSesi;
    public AudioClip kirliSuSesi;
    public AudioClip temizSuSesi;

    [Header("Yakalama Zorluk")]
    [Range(0.1f, 1f)]
    public float difficulty = 0.5f;

    [HideInInspector] public bool discovered;
    [HideInInspector] public bool caught;
}