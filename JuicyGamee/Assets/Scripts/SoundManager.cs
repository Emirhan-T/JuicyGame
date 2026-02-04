using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Clips")]
    public AudioClip uiClick;

    private AudioSource audioSource;

    private void Awake()
    {
        // Singleton: sahnede tek tane olsun
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Sahne deðiþse bile kalsýn istersen aç:
        // DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
    }

    public void PlayClick()
    {
        if (uiClick == null)
        {
            Debug.LogWarning("uiClick clip atanmadý!");
            return;
        }

        audioSource.PlayOneShot(uiClick);
    }

    // Ýstersen genel amaçlý:
    public void PlaySfx(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return;
        audioSource.PlayOneShot(clip, volume);
    }
}
