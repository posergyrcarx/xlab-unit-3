using System.Collections;
using Code.Interfaces;
using Code.Scripts.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts.Managers
{
    [DisallowMultipleComponent]
    public sealed class SceneLoader : MonoBehaviour, IManager
    {
        //  Load scene
        //  Wait scene to load
        //  Make it active
        //  Delete previous
        
        public void ChangeScene(string[] scenesToLoad)
        {
            var initialScene = SceneManager.GetActiveScene().name;
            
            if (scenesToLoad != null)
            {
                foreach (var i in scenesToLoad)
                {
                    StartCoroutine(LoadSceneAsync(i));
                }

                StartCoroutine(ChangeActiveScene(scenesToLoad[0], initialScene));
            }
            else
            {
                this.LogError("Array of scenes to load is null!");
            }
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            var loadAsync = 
                SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            
            while (!loadAsync.isDone)
            {
                var progress = loadAsync.progress;
                this.LogInfo("Scene loading: " + progress);
                
                yield return null;
            }

            this.LogSuccess("Scene loaded: " + sceneName);
            
            yield return null;
        }
        
        private IEnumerator ChangeActiveScene(string sceneToLoad, string sceneToUnload)
        {
            while (!SceneManager.GetSceneByName(sceneToLoad).isLoaded)
            {
                this.LogInfo("Waiting scene to load");
                
                yield return null;
            }
            
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoad));
            StartCoroutine(UnloadSceneAsync(sceneToUnload));
            
            yield return null;
        }
        
        private IEnumerator UnloadSceneAsync(string scene)
        {
            var unloadAsync =
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(scene));

            while (!unloadAsync.isDone)
            {
                var progress = unloadAsync.progress;
                this.LogInfo("Scene unloading: " + progress);
                
                yield return null;
            }

            this.LogInfo("Scene unloaded: " + scene);
            
            yield return null;
        }
    }
}