using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneManager : AManager
{
    [SerializeField] private string[] scenesToLoad;

    private void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;

        if (scenesToLoad != null)
        {
            foreach (string i in scenesToLoad)
            {
                LoadScene(i);
            }
        }
        else
        {
            Debug.LogError("No scenes has been set");
        }
    }
    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void LoadScene(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene, LoadSceneMode.Additive);

        Debug.Log($"Loading {scene}");
    }

    private void MakeFirstSceneActive()
    {
        UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName(scenesToLoad[0]));
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
        var preloader = UnityEngine.SceneManagement.SceneManager.GetSceneByName("Preloader");
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(preloader);
    }
}