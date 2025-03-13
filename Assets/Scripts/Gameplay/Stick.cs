using UnityEngine;
using UnityEngine.Events;

public class Stick : MonoBehaviour
{
    [SerializeField] private UnityEvent<Collider> onCollision;

    private void OnCollisionEnter(Collision collision)
    {
        onCollision.Invoke(collision.collider);
    }
}
