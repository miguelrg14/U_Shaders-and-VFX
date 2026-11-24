using UnityEngine;

namespace ShaderStudy
{
    /// <summary>
    /// Moves the object along X with A/D or the arrow keys; drifts back and forth on its own when idle.
    /// </summary>
    public class DemoSideScroller : MonoBehaviour
    {
        public float speed = 6f;
        public float autoRange = 15f;
        public float autoPeriod = 16f;

        private float startX;
        private float idleTime;
        private float autoTime;

        private void Start()
        {
            startX = transform.position.x;
        }

        private void Update()
        {
            float input = Input.GetAxisRaw("Horizontal");
            Vector3 p = transform.position;
            if (Mathf.Abs(input) > 0.01f)
            {
                idleTime = 0f;
                p.x += input * speed * Time.deltaTime;
            }
            else
            {
                idleTime += Time.deltaTime;
                if (idleTime > 2f)
                {
                    autoTime += Time.deltaTime;
                    float targetX = startX + Mathf.Sin(autoTime / autoPeriod * Mathf.PI * 2f) * autoRange;
                    p.x = Mathf.MoveTowards(p.x, targetX, speed * 0.5f * Time.deltaTime);
                }
            }
            transform.position = p;
        }
    }
}
