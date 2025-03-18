using UnityEngine;

namespace Packages.AlignedGames.Polygonal_Foliage_Asset_Package.Scripts.Utility
{
    public class FlyCameraBehaviour : MonoBehaviour
    {

        public float cameraSensitivity = 90;
        public float climbSpeed = 4;
        public float normalMoveSpeed = 10;
        public float slowMoveFactor = 0.25f;
        public float fastMoveFactor = 3;

        private float _rotationX = 0.0f;
        private float _rotationY = 0.0f;

        [System.Obsolete]
        private void Start()
        {
            Screen.lockCursor = true;
        }

        [System.Obsolete]
        private void Update()
        {
            _rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
            _rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
            _rotationY = Mathf.Clamp(_rotationY, -90, 90);

            transform.localRotation = Quaternion.AngleAxis(_rotationX, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(_rotationY, Vector3.left);

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                transform.position += transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                transform.position += transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
            }
            else
            {
                transform.position += transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            }


            if (Input.GetKey(KeyCode.Q)) { transform.position += transform.up * climbSpeed * Time.deltaTime; }
            if (Input.GetKey(KeyCode.E)) { transform.position -= transform.up * climbSpeed * Time.deltaTime; }

            if (Input.GetKeyDown(KeyCode.End))
            {
                Screen.lockCursor = (Screen.lockCursor == false) ? true : false;
            }
        }
    }
}