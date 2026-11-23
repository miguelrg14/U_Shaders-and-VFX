using UnityEngine;

namespace ShaderStudy
{
    /// <summary>
    /// Animates a float shader property so the effect is visible without touching the inspector.
    /// - Renderers are driven through a MaterialPropertyBlock (the material asset is not modified).
    /// - Materials (e.g. image-effect materials) are modified directly and restored on disable.
    /// Press the toggle key to pause/resume the animation and tweak the value by hand.
    /// </summary>
    public class DemoMaterialAnimator : MonoBehaviour
    {
        public enum Mode { PingPong, Loop, Smooth }

        public string propertyName = "_Cutoff";
        public Renderer[] renderers = new Renderer[0];
        public Material[] materials = new Material[0];
        public Mode mode = Mode.Smooth;
        public float from = 0f;
        public float to = 1f;
        [Tooltip("Seconds for a full from -> to cycle.")]
        public float duration = 3f;
        public float timeOffset = 0f;
        public KeyCode toggleKey = KeyCode.Space;
        public bool playing = true;

        private MaterialPropertyBlock block;
        private float[] originalValues;
        private float time;
        private int propertyId;

        private void OnEnable()
        {
            propertyId = Shader.PropertyToID(propertyName);
            block = new MaterialPropertyBlock();
            originalValues = new float[materials.Length];
            for (int i = 0; i < materials.Length; i++)
            {
                if (materials[i] != null && materials[i].HasProperty(propertyId))
                    originalValues[i] = materials[i].GetFloat(propertyId);
            }
            time = timeOffset;
        }

        private void OnDisable()
        {
            for (int i = 0; i < materials.Length; i++)
            {
                if (materials[i] != null && materials[i].HasProperty(propertyId))
                    materials[i].SetFloat(propertyId, originalValues[i]);
            }
            foreach (Renderer r in renderers)
            {
                if (r == null) continue;
                r.GetPropertyBlock(block);
                block.Clear();
                r.SetPropertyBlock(block);
            }
        }

        public float Evaluate(float t)
        {
            float d = Mathf.Max(0.0001f, duration);
            float k;
            switch (mode)
            {
                case Mode.Loop: k = Mathf.Repeat(t / d, 1f); break;
                case Mode.PingPong: k = Mathf.PingPong(t / d * 2f, 1f); break;
                default: k = 0.5f - 0.5f * Mathf.Cos(t / d * Mathf.PI * 2f); break;
            }
            return Mathf.Lerp(from, to, k);
        }

        private void Update()
        {
            if (Input.GetKeyDown(toggleKey)) playing = !playing;
            if (!playing) return;

            time += Time.deltaTime;
            float value = Evaluate(time);

            foreach (Material m in materials)
            {
                if (m != null) m.SetFloat(propertyId, value);
            }
            foreach (Renderer r in renderers)
            {
                if (r == null) continue;
                r.GetPropertyBlock(block);
                block.SetFloat(propertyId, value);
                r.SetPropertyBlock(block);
            }
        }
    }
}
