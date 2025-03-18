using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Code.Scripts.Gameplay
{
    public class StoneSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] stonePrefabs;
        [Space]
        [SerializeField] private float delayInSec = 0.50f;
        [SerializeField] private float delayMax = 2.00f;
        [SerializeField] private float delayMin = 2.00f;
        [SerializeField] private float delayStep = 0.10f;

        [FormerlySerializedAs("OnSceneLoaded")] [HideInInspector] public UnityEvent onSceneLoaded;
        private bool _coroutineStatus;

        private void Awake()
        {
            onSceneLoaded ??= new UnityEvent();
            onSceneLoaded?.Invoke();
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

        private void StartSpawn()
        {
            if (_coroutineStatus != true)
            {
                StartCoroutine(StartStoneProcess());
                SpawnRandomDelay();
            }
        }

        private void EndSpawn()
        {
            StopCoroutine(StartStoneProcess());
        }

        private IEnumerator StartStoneProcess()
        {
            _coroutineStatus = true;

            yield return new WaitForSeconds(delayInSec);
            Spawn();

            _coroutineStatus = false;
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
}
