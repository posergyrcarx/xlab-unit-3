using UnityEngine;
using UnityEngine.Events;

public sealed class LevelManager : AManager
{
    [HideInInspector] public UnityEvent OnSceneLoaded;

    [SerializeField] private StoneSpawner stoneSpawner;
    [SerializeField] private bool isGameOver;

    private void Awake()
    {
        OnSceneLoaded ??= new UnityEvent();
        OnSceneLoaded?.Invoke();

        Debug.Log("Scene loaded");
    }

    private void Update()
    {
        if (!isGameOver)
        {
            stoneSpawner.StartSpawn();
        }
        else
        {
            stoneSpawner.EndSpawn();
        }
    }
}