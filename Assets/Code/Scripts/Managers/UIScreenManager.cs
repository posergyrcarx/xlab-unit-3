using System;
using UnityEngine;

public sealed class UIScreenManager : AManager
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

    public void EnableMainMenu(GameManager gameManager)
    {
        UpdateUi(UiScreenState.MainMenu);
    }

    public void EnableSettingsMenu(GameManager gameManager)
    {
        UpdateUi(UiScreenState.SettingsMenu);
    }

    public void EnableGameplay(GameManager gameManager)
    {
        UpdateUi(UiScreenState.Gameplay);
    }

    public void EnableGameOver(GameManager gameManager)
    {
        UpdateUi(UiScreenState.GameOver);
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