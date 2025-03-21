using UnityEngine;

namespace Code.Scripts.Helpers
{
    public class DestroyAfterTime : MonoBehaviour
    {
        [SerializeField] private float deleteAfterSec = 5.00f;

        private void Awake()
        {
            Destroy(gameObject, deleteAfterSec);
        }
    }
}