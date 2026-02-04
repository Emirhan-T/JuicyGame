using UnityEngine;

public class MixerController : MonoBehaviour
{
    [Header("UI")]
    public GameObject MixerPanel;

    [Header("Optional")]
    public Camera targetCamera; // boþ býrakýrsan Camera.main kullanýr

    private void Awake()
    {
        if (targetCamera == null) targetCamera = Camera.main;

        // Güvenlik: baþlangýçta kapalý olsun istiyorsan
        // if (MixerPanel != null) MixerPanel.SetActive(false);
    }

    private void Update()
    {
        // Mobil dokunma
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                TryOpenPanel(t.position);
            }
        }

        // Editor / PC testi için mouse
        if (Input.GetMouseButtonDown(0))
        {
            TryOpenPanel(Input.mousePosition);
        }
    }

    private void TryOpenPanel(Vector2 screenPos)
    {
        if (targetCamera == null) return;

        Vector2 worldPoint = targetCamera.ScreenToWorldPoint(screenPos);

        // Nokta testi: bu worldPoint collider içinde mi?
        Collider2D hit = Physics2D.OverlapPoint(worldPoint);

        if (hit != null && hit.gameObject == gameObject)
        {
            if (MixerPanel != null)
                MixerPanel.SetActive(true);
            else
                Debug.LogWarning("MixerPanel atanmadý! Inspector'dan sürükleyip býrak.");
        }
    }

    // Ýstersen paneli kapatmak için dýþarýdan çaðýr
    public void CloseMixerPanel()
    {
        if (MixerPanel != null) MixerPanel.SetActive(false);
    }
}
