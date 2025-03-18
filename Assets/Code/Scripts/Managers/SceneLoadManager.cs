using System.Collections;
using Code.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts.Managers
{
    [DisallowMultipleComponent]
    public sealed class SceneLoadManager : MonoBehaviour, IManager
    {
        [SerializeField] private string[] scenesToLoad = 
        { 
            "LevelGolf"
        };

        public void LoadScenes()
        {
            if (scenesToLoad != null)
            {
                foreach (var i in scenesToLoad)
                {
                    StartCoroutine(LoadSceneAsync(i));
                }
            }
            else
            {
#if UNITY_EDITOR
                Debug.LogError("No scenes has been set");
#endif
            }
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            var asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            while (asyncLoad is { isDone: false })
            {
                var progress = asyncLoad.progress;
                
#if UNITY_EDITOR
                Debug.Log("Loading Progress: " + progress);
#endif

                yield return null;
            }

#if UNITY_EDITOR
            Debug.Log("Scene Loaded: " + sceneName);
#endif
        
            MakeFirstSceneActive();
            UnloadPreloader();
        }

        private void MakeFirstSceneActive()
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scenesToLoad[0]));
        }

        private static void UnloadPreloader()
        {
            var preloader = SceneManager.GetSceneByName("Preloader");
            SceneManager.UnloadSceneAsync(preloader);
        }
    }
}