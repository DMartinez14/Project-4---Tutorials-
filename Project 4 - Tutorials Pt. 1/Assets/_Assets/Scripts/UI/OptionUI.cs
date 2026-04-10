using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionUI : MonoBehaviour
{
    public static OptionUI Instance { get; private set; }
 [SerializeField] private Button soundEffectsButton;
[SerializeField] private Button musicButton;
[SerializeField] private Button CloseButton;

[SerializeField] private TextMeshProUGUI soundEffectsText;
[SerializeField] private TextMeshProUGUI musicText;


private void Awake()
    {
        
        soundEffectsButton.onClick.AddListener(() =>
        {
            //Click
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });
          musicButton.onClick.AddListener(() =>
        {
            //Click
            MusicManager.Instance.ChangeVolume();
             UpdateVisual();
        });
            CloseButton.onClick.AddListener(() =>
            {
                //Click
                Hide();
            });
    }
    private void Start()
    {
        KitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnGamePaused;
        UpdateVisual();
            Hide();
    }
    private void KitchenGameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        Hide();
    }
    private void UpdateVisual()
    {
        soundEffectsText.text = "Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
     public void Hide()
    {
        gameObject.SetActive(false);
    }

}
