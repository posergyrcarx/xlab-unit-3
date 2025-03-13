using UnityEngine;

public class Stone : MonoBehaviour
{
    private bool isAffect = false;

    public static System.Action OnCollisionStone;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Stone other))
        {
            if (!other.isAffect)
            {
                OnCollisionStone.Invoke();
            }
        }
    }

    public void SwitchAffect(bool affect)
    {
        isAffect = affect;
    }
}
