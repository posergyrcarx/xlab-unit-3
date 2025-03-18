using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] stonePrefabs;
    [Space]
    [SerializeField] private float delayInSec = 0.50f;
    [SerializeField] private float delayMax = 2.00f;
    [SerializeField] private float delayMin = 2.00f;
    [SerializeField] private float delayStep = 0.10f;

    [HideInInspector] public UnityEvent OnSceneLoaded;
    private bool coroutineStatus;

    private void Awake()
    {
        OnSceneLoaded ??= new UnityEvent();
        OnSceneLoaded?.Invoke();
    }

    private void Update()
    {
        if (true) //Should it spawn 
        {
            StartSpawn();
        }
        else
        {
            EndSpawn();
        }
    }

    public void StartSpawn()
    {
        if (coroutineStatus != true)
        {
            StartCoroutine(StartStoneProcess());
            SpawnRandomDelay();
        }
    }

    public void EndSpawn()
    {
        StopCoroutine(StartStoneProcess());
    }

    private IEnumerator StartStoneProcess()
    {
        coroutineStatus = true;

        yield return new WaitForSeconds(delayInSec);
        Spawn();

        coroutineStatus = false;
    }

    private void Spawn()
    {
        Instantiate(GetRandomStone(), transform.position, Quaternion.identity, transform);
        SpawnRandomDelay();
    }

    private void SpawnRandomDelay()
    {
        delayInSec = Random.Range(delayMin, delayMax);
        delayMax = Mathf.Max(delayMin, delayMax - delayStep);
    }

    private GameObject GetRandomStone()
    {
        if (stonePrefabs == null)
        {
#if UNITY_EDITOR
            Debug.LogError("Stone list is empty!");
#endif
            return null;
        }
        else
        {
            var index = Random.Range(0, stonePrefabs.Length);
            return stonePrefabs[index];
        }
    }
}
