using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{

    public static GamePauseUI Instance { get; private set; }
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionButton;

    
    private void Awake()
    {
        Instance = this;

        resumeButton.onClick.AddListener(() =>
        {
            //Click
            KitchenGameManager.Instance.TogglePauseGame();
        });
          mainMenuButton.onClick.AddListener(() =>
        {
            //Click
            Loader.Load(Loader.Scene.MainMenuScene);
        });
            optionButton.onClick.AddListener(() =>
            {
                //Click
                OptionUI.Instance.Show();
            });
    }
    private void Start()
    {
        KitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnGamePaused;
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
            Hide();
    }
    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }
    private void KitchenGameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        Show();
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
