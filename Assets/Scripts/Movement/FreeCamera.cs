using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class FreeCamera : MonoBehaviour
{

    [SerializeField] private float speed = 1.5f;
	[SerializeField] private float defaultAcceleration = 10.00f;
	private float acceleration = 1.00f;

    [SerializeField] private float sensitivity = 5.00f; // чувствительность мыши
    [SerializeField] private Camera mainCamera;
	//public BoxCollider boxCollider;

	private Rigidbody body;
	private float rotY;
	private Vector3 direction;

	void Start()
	{
		body = GetComponent<Rigidbody>();
		body.freezeRotation = true;
		body.useGravity = false;
		body.mass = 0.1f;
		body.linearDamping = 10;

		//SetBoxColliderSize();
	}

	/*public void SetBoxColliderSize()
	{
		Vector3 point_A = mainCamera.ScreenPointToRay(Vector2.zero).origin;

		// определяем размер коллайдера по ширине экрана
		Vector3 point_B = mainCamera.ScreenPointToRay(new Vector2(Screen.width, 0)).origin;

		float dist = Vector3.Distance(point_A, point_B);
		boxCollider.size = new Vector3(dist, boxCollider.size.y, 0.1f);

		// определяем размер бокса по высоте
		point_B = mainCamera.ScreenPointToRay(new Vector2(0, Screen.height)).origin;

		dist = Vector3.Distance(point_A, point_B);
		boxCollider.size = new Vector3(boxCollider.size.x, dist, 0.1f);

		boxCollider.center = new Vector3(0, 0, mainCamera.nearClipPlane);
	}*/

	void Update()
	{
		Move();
	}

	void Move()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		float rotX = mainCamera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
		rotY += Input.GetAxis("Mouse Y") * sensitivity;
		rotY = Mathf.Clamp(rotY, -90, 90);

		if (Input.GetKey(KeyCode.Mouse1))
		{
			mainCamera.transform.localEulerAngles = new Vector3(-rotY, rotX, 0);
		}

		direction = new Vector3(h, 0, v);
		direction = mainCamera.transform.TransformDirection(direction);
	}

	public void CameraIncreaseSpeed(bool key)
	{
        if (key)
        {
			acceleration = defaultAcceleration;
        }
        else
		{
			acceleration = 1.00f;
        }
    }


    void FixedUpdate()
	{
		body.AddForce(direction.normalized * speed * acceleration);

		if (Mathf.Abs(body.linearVelocity.x) > speed) body.linearVelocity = new Vector3(Mathf.Sign(body.linearVelocity.x) * speed, body.linearVelocity.y, body.linearVelocity.z);
		if (Mathf.Abs(body.linearVelocity.z) > speed) body.linearVelocity = new Vector3(body.linearVelocity.x, body.linearVelocity.y, Mathf.Sign(body.linearVelocity.z) * speed);
		if (Mathf.Abs(body.linearVelocity.y) > speed) body.linearVelocity = new Vector3(body.linearVelocity.x, Mathf.Sign(body.linearVelocity.y) * speed, body.linearVelocity.z);
	}
}
