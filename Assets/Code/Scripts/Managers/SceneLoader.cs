using Code.Interfaces;
using Code.Tools;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public sealed class SceneLoader : MonoBehaviour, IManager
{
    public void ChangeSceneSet(string[] scenesToLoad)
    {
        var scene = SceneManager.GetActiveScene().name;

        StartCoroutine(ChangeScene(scenesToLoad, scene));
    }

    IEnumerator ChangeScene(string[] scenesToLoad, string scene)
    {
        LoadScenes(scenesToLoad);
        yield return UnloadPreviousScene(scene);
    }

    IEnumerator UnloadPreviousScene(string scene)
    {
        if (scene != SceneManager.GetActiveScene().name)
        {
            yield return null;
        }

        AsyncOperation unloadOperation =
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(scene));

        while (!unloadOperation.isDone)
        {
            yield return null;
        }

        this.LogInfo("Scene unloaded: " + scene);
    }

    public void LoadScenes(string[] scenesToLoad)
    {
        if (scenesToLoad == null)
        {
            return;
        }

        foreach (string i in scenesToLoad)
        {
            StartCoroutine(LoadSceneAsync(i));
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = 
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            float progress = asyncLoad.progress;
            this.LogInfo("Scene loading: " + progress);

            yield return null;
        }

        this.LogSuccess("Scene loaded: " + sceneName);
        MakeFirstSceneActive(sceneName);
    }

    private void MakeFirstSceneActive(string sceneName)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }
}