using Code.Tools;
using UnityEngine;

[DisallowMultipleComponent]
public class UIScreenManager : PersistentSingleton<MonoBehaviour>, IManager
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject gameplayHud;
    [SerializeField] private GameObject gameOver;

    private void OnEnable()
    {
        GameManager.OnMainMenuRunningEvent += EnableMainMenu;
        GameManager.OnSettingsRunningEvent += EnableSettingsMenu;
        GameManager.OnGameplayEvent += EnableGameplay;
        GameManager.OnGameOverEvent += EnableGameOver;
    }

    private void OnDisable()
    {
        GameManager.OnMainMenuRunningEvent -= EnableMainMenu;
        GameManager.OnSettingsRunningEvent -= EnableSettingsMenu;
        GameManager.OnGameplayEvent -= EnableGameplay;
        GameManager.OnGameOverEvent -= EnableGameOver;
    }

    private enum UiScreenState
    {
        MainMenu,
        SettingsMenu,
        Gameplay,
        GameOver 
    }

    [Space]
    [SerializeField] private UiScreenState uiScreenState;

    public void EnableMainMenu()
    {
        UpdateUi(UiScreenState.MainMenu);

#if UNITY_EDITOR
        Debug.Log("UI Loaded: Main Menu");
#endif
    }

    public void EnableSettingsMenu()
    {
        UpdateUi(UiScreenState.SettingsMenu);

#if UNITY_EDITOR
        Debug.Log("UI Loaded: Settings");
#endif
    }

    public void EnableGameplay()
    {
        UpdateUi(UiScreenState.Gameplay);

#if UNITY_EDITOR
        Debug.Log("UI Loaded: Gameplay");
#endif
    }

    public void EnableGameOver()
    {
        UpdateUi(UiScreenState.GameOver);

#if UNITY_EDITOR
        Debug.Log("UI Loaded: GameOver");
#endif
    }

    private void UpdateUi(UiScreenState uiScreenState)
    {
        switch (uiScreenState)
        {
            case UiScreenState.MainMenu:
                mainMenuCanvas.SetActive(true);
                settingsMenu.SetActive(false);
                gameplayHud.SetActive(false);
                gameOver.SetActive(false);
                break;
            case UiScreenState.SettingsMenu:
                mainMenuCanvas.SetActive(false);
                settingsMenu.SetActive(true);
                gameplayHud.SetActive(false);
                gameOver.SetActive(false);
                break;
            case UiScreenState.Gameplay:
                mainMenuCanvas.SetActive(false);
                settingsMenu.SetActive(false);
                gameplayHud.SetActive(true);
                gameOver.SetActive(false);
                break;
            case UiScreenState.GameOver:
                mainMenuCanvas.SetActive(false);
                settingsMenu.SetActive(false);
                gameplayHud.SetActive(false);
                gameOver.SetActive(true);
                break;
        }
    }
}