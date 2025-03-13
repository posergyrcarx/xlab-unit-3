using System.Collections;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] stonePrefabs;
    [Space]
    [SerializeField] private float delayInSec = 0.50f;
    [SerializeField] private float delayMax = 2.00f;
    [SerializeField] private float delayMin = 2.00f;
    [SerializeField] private float delayStep = 0.10f;

    private bool coroutineStatus;

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
        Instantiate(GetRandomStone(), transform.position, Quaternion.identity);
        SpawnRandomDelay();
    }

    private void SpawnRandomDelay()
    {
        delayInSec = UnityEngine.Random.Range(delayMin, delayMax);
        delayMax = Mathf.Max(delayMin, delayMax - delayStep);
    }

    private GameObject GetRandomStone()
    {
        if (stonePrefabs == null)
        {
            Debug.LogError("Stone list is empty!");
            return null;
        }
        else
        {
            var index = Random.Range(0, stonePrefabs.Length);
            return stonePrefabs[index];
        }
    }
}
