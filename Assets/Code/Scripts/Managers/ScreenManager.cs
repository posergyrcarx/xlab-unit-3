using Code.Tools;
using System;
using UnityEngine;

[DisallowMultipleComponent]
public class ScreenManager : MonoBehaviour, IManager
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject gameplayHud;
    [SerializeField] private GameObject gameOver;

    private void OnEnable()
    {
        GameManager.OnMainMenuEvent += EnableMainMenu;
        GameManager.OnSettingsEvent += EnableSettingsMenu;
        GameManager.OnGameplayEvent += EnableGameplay;
        GameManager.OnGameOverEvent += EnableGameOver;

        DebugMenu.OnUpdateUiEvent += ReloadScreen;
    }

    private void OnDisable()
    {
        GameManager.OnMainMenuEvent -= EnableMainMenu;
        GameManager.OnSettingsEvent -= EnableSettingsMenu;
        GameManager.OnGameplayEvent -= EnableGameplay;
        GameManager.OnGameOverEvent -= EnableGameOver;

        DebugMenu.OnUpdateUiEvent -= ReloadScreen;
    }

    private enum screenState
    {
        None = 0,
        MainMenu,
        SettingsMenu,
        Gameplay,
        GameOver
    }

    [Space]
    [SerializeField] private screenState ScreenState = screenState.None;

    public void EnableMainMenu()
    {
        UpdateUi(screenState.MainMenu);
        LoadStatusDebugMessage("Main Menu");
    }

    public void EnableSettingsMenu()
    {
        UpdateUi(screenState.SettingsMenu);
        LoadStatusDebugMessage("Settings");
    }

    public void EnableGameplay()
    {
        UpdateUi(screenState.Gameplay);
        LoadStatusDebugMessage("Gameplay");
    }

    public void EnableGameOver()
    {
        UpdateUi(screenState.GameOver);
        LoadStatusDebugMessage("GameOver");
    }

    private void UpdateUi(screenState screenState)
    {
        switch (screenState)
        {
            case screenState.None:
                mainMenuCanvas.SetActive(false);
                settingsMenu.SetActive(false);
                gameplayHud.SetActive(false);
                gameOver.SetActive(false);
                break;
            case screenState.MainMenu:
                mainMenuCanvas.SetActive(true);
                settingsMenu.SetActive(false);
                gameplayHud.SetActive(false);
                gameOver.SetActive(false);
                break;
            case screenState.SettingsMenu:
                mainMenuCanvas.SetActive(false);
                settingsMenu.SetActive(true);
                gameplayHud.SetActive(false);
                gameOver.SetActive(false);
                break;
            case screenState.Gameplay:
                mainMenuCanvas.SetActive(false);
                settingsMenu.SetActive(false);
                gameplayHud.SetActive(true);
                gameOver.SetActive(false);
                break;
            case screenState.GameOver:
                mainMenuCanvas.SetActive(false);
                settingsMenu.SetActive(false);
                gameplayHud.SetActive(false);
                gameOver.SetActive(true);
                break;
        }
    }

    private void ReloadScreen()
    {
        UpdateUi(ScreenState);
    }

    private void LoadStatusDebugMessage(string uiName)
    {
        this.LogSuccess("UI Loaded: " + uiName);
    }
}