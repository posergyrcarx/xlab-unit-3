using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SceneLoadManager sceneLoadManager;
    [SerializeField] private UIScreenManager uisManager;

    public static event Action OnPreloaderRunningEvent;
    public static event Action OnMainMenuRunningEvent;
    public static event Action OnSettingsRunningEvent;
    public static event Action OnGameplayEvent;
    public static event Action OnGameOverEvent;

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
    public GameState state = GameState.Preloader;

    public GameState State => state;

    public void ChangeState(GameState gameState)
    {
        OnBeforeStateChanged?.Invoke(gameState);

        state = gameState;

        switch (gameState)
        {
            case GameState.Preloader:
#if UNITY_EDITOR
                Debug.Log($"Game state: {gameState}");
#endif
                HandlePreloader();
                break;
            case GameState.MainMenu:
#if UNITY_EDITOR
                Debug.Log($"Game state: {gameState}");
#endif
                HandleMainMenu();
                sceneLoadManager.StartupSceneLoader();
                break;
            case GameState.Settings:
#if UNITY_EDITOR
                Debug.Log($"Game state: {gameState}");
#endif
                HandleSettings();
                break;
            case GameState.Gameplay:
#if UNITY_EDITOR
                Debug.Log($"Game state: {gameState}");
#endif
                HandleGameplay();
                break;
            case GameState.GameOver:
#if UNITY_EDITOR
                Debug.Log($"Game state: {gameState}");
#endif
                HandleGameOver();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), state, null);
        }

        OnAfterStateChanged?.Invoke(gameState);
    }

    private void HandlePreloader()
    {
        OnPreloaderRunningEvent?.Invoke();
    }

    private void HandleMainMenu()
    {
        OnMainMenuRunningEvent?.Invoke();
    }

    private void HandleSettings()
    {
        OnSettingsRunningEvent?.Invoke();
    }

    private void HandleGameplay()
    {
        OnGameplayEvent?.Invoke();
    }

    private void HandleGameOver()
    {
        OnGameOverEvent?.Invoke();
    }
}
