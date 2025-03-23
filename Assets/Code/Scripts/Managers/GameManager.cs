using System;
using Code.Interfaces;
using Code.ScriptableObjects;
using Code.Scripts.Debug;
using Code.Scripts.Helpers;
using UnityEngine;

namespace Code.Scripts.Managers
{
    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour, IManager
    {
        public GameState gameState = GameState.Preloader;
        [Space]
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private ScreenManager screenManager;
        [Space]
        [SerializeField] private ListScenes listScenes;
        [SerializeField] private string[] loadScenes;

        public static event Action OnMainMenuEvent;
        public static event Action OnGameplayEvent;
        public static event Action OnGameOverEvent;

        public static event Action<GameState> OnBeforeStateChanged;
        public static event Action<GameState> OnAfterStateChanged;

        [Serializable]
        public enum GameState
        {
            Preloader = 0,          // Preloader state
            MainMenu,               // Main menu and settings
            Gameplay,               // Main gameplay
            GameOver                // Game over and saving score
        }

        private void OnEnable()
        {
            DebugMenu.OnReloadGameEvent += ReloadGame;
        }
        private void OnDisable()
        {
            DebugMenu.OnReloadGameEvent -= ReloadGame;
        }

        public void SetState(GameState gameState)
        {
            OnBeforeStateChanged?.Invoke(gameState);

            switch (gameState)
            {
                case GameState.Preloader:
                    LoadStatusDebugMessage(GameState.Preloader);
                    HandlePreloader();
                    break;
                case GameState.MainMenu:
                    LoadStatusDebugMessage(GameState.MainMenu);
                    HandleMainMenu();
                    break;
                case GameState.Gameplay:
                    LoadStatusDebugMessage(GameState.Gameplay);
                    HandleGameplay();
                    break;
                case GameState.GameOver:
                    LoadStatusDebugMessage(GameState.GameOver);
                    HandleGameOver();
                    break;
                default:
                    break;
            }

            OnAfterStateChanged?.Invoke(gameState);
        }

        private void HandlePreloader()
        {
            loadScenes = listScenes.ScenesToLoad;

            sceneLoader.ChangeScene(loadScenes);
            SetState(GameState.MainMenu);
        }

        private void HandleMainMenu()
        {
            OnMainMenuEvent?.Invoke();
        }

        private void HandleGameplay()
        {
            OnGameplayEvent?.Invoke();
        }

        private void HandleGameOver()
        {
            OnGameOverEvent?.Invoke();
        }

        private void ReloadGame()
        {
            SetState(GameState.Preloader);
        }

        private void LoadStatusDebugMessage(GameState gameState)
        {
            this.LogInfo("Game state: " + gameState);
        }
    }
}
