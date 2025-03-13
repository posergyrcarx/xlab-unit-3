using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
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

    private void Start()
    {
        Stone.OnCollisionStone += GameOver;
    }

    private void OnEnable()
    {
        Stone.OnCollisionStone += GameOver;
    }
    private void OnDisable()
    {
        Stone.OnCollisionStone -= GameOver;
    }

    private void GameOver()
    {
        isGameOver = true;
        Debug.Log("GAME OVER");
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