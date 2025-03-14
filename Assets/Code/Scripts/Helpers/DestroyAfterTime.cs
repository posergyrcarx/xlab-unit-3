using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float deleteAfterSec = 5.00f;

    private void Awake()
    {
        Destroy(gameObject, deleteAfterSec);
    }
}