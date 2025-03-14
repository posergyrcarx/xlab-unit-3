using UnityEngine;

public sealed class UIScreenManager : AManager
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private GameObject GameplayHud;

    private enum UiScreenState
    {
        MainMenu,
        SettingsMenu,
        GameplayHud
    }

    [Space]
    [SerializeField] private UiScreenState uiScreenState;

    private void Awake()
    {
        uiScreenState = UiScreenState.MainMenu;
    }

    public void EnableMainMenu()
    {
        uiScreenState = UiScreenState.MainMenu;
    }

    public void EnableSettingsMenu()
    {
        uiScreenState = UiScreenState.SettingsMenu;
    }

    public void EnableGameplay()
    {
        uiScreenState = UiScreenState.GameplayHud;
    }

    private void UpdateUi(UiScreenState uiScreenState)
    {
        switch (uiScreenState)
        {
            case UiScreenState.MainMenu:
                mainMenuCanvas.SetActive(true);
                SettingsMenu.SetActive(false);
                GameplayHud.SetActive(false);
                break;
            case UiScreenState.SettingsMenu:
                mainMenuCanvas.SetActive(false);
                SettingsMenu.SetActive(true);
                GameplayHud.SetActive(false);
                break;
            case UiScreenState.GameplayHud:
                mainMenuCanvas.SetActive(false);
                SettingsMenu.SetActive(false);
                GameplayHud.SetActive(true);
                break;
        }
    }
}