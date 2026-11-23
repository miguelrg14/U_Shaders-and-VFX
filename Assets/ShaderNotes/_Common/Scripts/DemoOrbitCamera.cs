using UnityEngine;

namespace ShaderStudy
{
    /// <summary>
    /// Simple orbit camera for inspecting the demos.
    /// Right mouse drag = orbit, mouse wheel = zoom, middle mouse drag = pan.
    /// The initial view is taken from the camera's transform in the scene.
    /// </summary>
    public class DemoOrbitCamera : MonoBehaviour
    {
        public Vector3 target = Vector3.zero;
        public float rotateSpeed = 4f;
        public float zoomSpeed = 2f;
        public float panSpeed = 0.02f;
        public float minDistance = 0.5f;
        public float maxDistance = 200f;
        [Tooltip("Degrees per second of automatic orbit (0 = disabled).")]
        public float autoOrbitSpeed = 0f;

        private float yaw;
        private float pitch;
        private float distance;

        private void Start()
        {
            Vector3 offset = transform.position - target;
            distance = Mathf.Max(minDistance, offset.magnitude);
            Vector3 euler = Quaternion.LookRotation(-offset.normalized, Vector3.up).eulerAngles;
            yaw = euler.y;
            pitch = euler.x > 180f ? euler.x - 360f : euler.x;
        }

        private void LateUpdate()
        {
            if (Input.GetMouseButton(1))
            {
                yaw += Input.GetAxis("Mouse X") * rotateSpeed;
                pitch -= Input.GetAxis("Mouse Y") * rotateSpeed;
            }
            else
            {
                yaw += autoOrbitSpeed * Time.deltaTime;
            }
            pitch = Mathf.Clamp(pitch, -85f, 85f);

            float wheel = Input.mouseScrollDelta.y;
            if (Mathf.Abs(wheel) > 0.001f)
            {
                distance *= Mathf.Pow(0.9f, wheel * zoomSpeed);
                distance = Mathf.Clamp(distance, minDistance, maxDistance);
            }

            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
            if (Input.GetMouseButton(2))
            {
                Vector3 pan = rotation * new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0f);
                target += pan * panSpeed * distance;
            }

            transform.rotation = rotation;
            transform.position = target - rotation * Vector3.forward * distance;
        }
    }
}
