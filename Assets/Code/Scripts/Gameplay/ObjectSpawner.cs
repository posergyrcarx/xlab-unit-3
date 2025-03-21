using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Code.Gameplay.Level
{
    public class Spawner : MonoBehaviour
    {
        [SerializedDictionary("Spawner", "ObjectToSpawn")] 
        [SerializeField] private SerializedDictionary<Transform, GameObject> slots;
        [SerializeField] private bool spawnOnLoad = true;

        private void Awake()
        {
            if (spawnOnLoad)
            {
                Instantiate();
            }
        }

        private void Instantiate()
        {
            foreach (var spawner in slots)
            {
                var pos = spawner.Key.position;
                
                var position = new Vector3(pos.x, pos.y, pos.z);
                var rotation = spawner.Key.transform.rotation.eulerAngles;
                
                Instantiate(spawner.Value, position, Quaternion.Euler(rotation));
            }
        }

        private void OnDrawGizmosSelected()
        {
            foreach (var spawner in slots)
            {
                Gizmos.color = new Color(0, 0.50f, 1.00f, 0.75f);
                Gizmos.DrawSphere(spawner.Key.transform.position, 0.50f);
            }
        }
    }
}