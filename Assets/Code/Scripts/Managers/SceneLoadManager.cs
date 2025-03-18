using System.Collections;
using Code.Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            foreach (string i in scenesToLoad)
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

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            float progress = asyncLoad.progress;
            Debug.Log("Loading Progress: " + progress);

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

    private void UnloadPreloader()
    {
        var preloader = SceneManager.GetSceneByName("Preloader");
        SceneManager.UnloadSceneAsync(preloader);
    }
}