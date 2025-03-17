using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SceneLoadManager sceneLoadManager;
    [SerializeField] private UIScreenManager uisManager;

    public static event Action<GameManager> OnPreloaderRunningEvent;
    public static event Action<GameManager> OnMainMenuRunningEvent;
    public static event Action<GameManager> OnSettingsRunningEvent;
    public static event Action<GameManager> OnGameplayEvent;
    public static event Action<GameManager> OnGameOverEvent;

    [Serializable]
    public enum GameState
    {
        Preloader,
        MainMenu,
        Settings,
        Gameplay,
        GameOver
    }

    [HideInInspector] 
    public static event Action<GameState> OnBeforeStateChanged;
    [HideInInspector]
    public static event Action<GameState> OnAfterStateChanged;

    [Space]
    public GameState state;

    public GameState State => state;

    public void ChangeState(GameState gameState)
    {
        OnBeforeStateChanged?.Invoke(gameState);

        state = gameState;

        switch (gameState)
        {
            case GameState.Preloader:
                HandlePreloader();
                break;
            case GameState.MainMenu:
                HandleMainMenu();
                break;
            case GameState.Settings:
                HandleSettings();
                break;
            case GameState.Gameplay:
                HandleGameplay();
                break;
            case GameState.GameOver:
                HandleGameOver();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), state, null);
        }

        OnAfterStateChanged?.Invoke(gameState);
#if UNITY_EDITOR
        Debug.Log($"Game state has changed to: {gameState}");
#endif
    }

    private void HandlePreloader()
    {
        OnPreloaderRunningEvent?.Invoke(this);
    }

    private void HandleMainMenu()
    {
        OnMainMenuRunningEvent?.Invoke(this);
    }

    private void HandleSettings()
    {
        OnSettingsRunningEvent?.Invoke(this);
    }

    private void HandleGameplay()
    {
        OnGameplayEvent?.Invoke(this);
    }

    private void HandleGameOver()
    {
        OnGameOverEvent?.Invoke(this);
    }
}
