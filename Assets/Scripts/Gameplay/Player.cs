using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform stick;
    [SerializeField] private Transform helper;
    private Vector3 m_lastPos;

    [Space]
    [SerializeField] private float range = 40.00f;
    [SerializeField] private float speed = 500.00f;
    [SerializeField] private float power = 20.00f;

    private bool m_isDown = false;

    private void Update()
    {
        m_lastPos = helper.position;
        m_isDown = Input.GetMouseButtonDown(0);

        Quaternion rot = stick.localRotation;
        Quaternion toRot = Quaternion.Euler(0, 0, m_isDown ? range : -range);

        rot = Quaternion.RotateTowards(rot, toRot, speed * Time.deltaTime);
        stick.localRotation = rot;
    }

    public void OnCollisionStick(Collider collider)
    {
        if (collider.TryGetComponent(out Rigidbody body))
        {
            //var dir = m_isDown ? stick.right : -stick.right;
            var dir = (helper.position.normalized - m_lastPos).normalized;
            body.AddForce(dir * power, ForceMode.Impulse);

            if (collider.TryGetComponent(out Stone stone))
            {
                stone.SwitchAffect(true);
            }
        }
    }
}
