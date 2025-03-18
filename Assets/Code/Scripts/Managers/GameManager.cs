using System;
using Code.Interfaces;
using UnityEngine;

namespace Code.Scripts.Managers
{
    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour, IManager
    {
        [SerializeField] private SceneLoadManager sceneLoadManager;
        [SerializeField] private UIScreenManager uiManager;

        public static event Action OnMainMenuRunningEvent;
        public static event Action OnGameplayEvent;
        public static event Action OnGameOverEvent;

        [Serializable]
        public enum GameState
        {
            StartUp,
            MainMenu,
            Gameplay,
            GameOver
        }

        public static event Action<GameState> OnBeforeStateChanged;
        public static event Action<GameState> OnAfterStateChanged;

        [Space]
        public GameState state = GameState.StartUp;

        public void SetState(GameState gameState)
        {
            OnBeforeStateChanged?.Invoke(gameState);

            switch (gameState)
            {
                case GameState.StartUp:
                    throw new NotImplementedException();
                case GameState.MainMenu:
#if UNITY_EDITOR
                    Debug.Log($"Game state: {gameState}");
#endif
                    sceneLoadManager.LoadScenes();
                    HandleMainMenu();
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

        private static void HandleMainMenu()
        {
            OnMainMenuRunningEvent?.Invoke();
        }

        private static void HandleGameplay()
        {
            OnGameplayEvent?.Invoke();
        }

        private static void HandleGameOver()
        {
            OnGameOverEvent?.Invoke();
        }
    }
}
