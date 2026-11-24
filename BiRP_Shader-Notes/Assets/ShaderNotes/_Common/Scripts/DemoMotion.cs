using UnityEngine;

namespace ShaderStudy
{
    /// <summary>
    /// Small procedural motion for demo objects: constant rotation plus a sine oscillation
    /// of the local position (both optional).
    /// </summary>
    public class DemoMotion : MonoBehaviour
    {
        [Header("Rotation (degrees per second)")]
        public Vector3 rotationSpeed = Vector3.zero;
        public Space rotationSpace = Space.Self;

        [Header("Oscillation")]
        public Vector3 amplitude = Vector3.zero;
        public float period = 4f;
        public float phase = 0f;

        private Vector3 startPosition;

        private void Start()
        {
            startPosition = transform.localPosition;
        }

        private void Update()
        {
            if (rotationSpeed != Vector3.zero)
                transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpace);

            if (amplitude != Vector3.zero && period > 0f)
            {
                float s = Mathf.Sin((Time.time / period + phase) * Mathf.PI * 2f);
                transform.localPosition = startPosition + amplitude * s;
            }
        }
    }
}
