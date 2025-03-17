using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneLoadManager : AManager
{
    [SerializeField] private string[] scenesToLoad;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (scenesToLoad != null)
        {
            foreach (string i in scenesToLoad)
            {
                LoadScene(i);
            }
        }
        else
        {
#if UNITY_EDITOR
            Debug.LogError("No scenes has been set");
#endif
        }
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
#if UNITY_EDITOR
        Debug.Log($"Loading {scene}");
#endif
    }

    private void MakeFirstSceneActive()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scenesToLoad[0]));
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == scenesToLoad[0])
        {
            MakeFirstSceneActive();
            UnloadPreloader();
        }
    }

    private void UnloadPreloader()
    {
        var preloader = SceneManager.GetSceneByName("Preloader");
        SceneManager.UnloadSceneAsync(preloader);
    }
}