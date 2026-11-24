using UnityEngine;

namespace ShaderStudy
{
    /// <summary>
    /// Builds and configures a ParticleSystem from a handful of fields when entering Play mode.
    /// Several of these shaders read the vertex colour alpha (which particles fade over their
    /// lifetime) to drive a dissolve / cutoff, so most VFX demos are shown through particles.
    /// </summary>
    public class DemoParticleEmitter : MonoBehaviour
    {
        public enum Shape { Cone, Sphere, Circle, Box }

        [Header("Rendering")]
        public Material material;
        public ParticleSystemRenderMode renderMode = ParticleSystemRenderMode.Billboard;
        public Mesh mesh;

        [Header("Emission")]
        public float rate = 10f;
        public int maxParticles = 500;
        public Vector2 lifetime = new Vector2(1f, 2f);
        public Vector2 speed = new Vector2(1f, 2f);
        public Vector2 size = new Vector2(0.5f, 1f);
        public bool randomRotation = true;
        public Color startColor = Color.white;
        public float gravity = 0f;
        public bool worldSpace = true;

        [Header("Shape")]
        public Shape shape = Shape.Cone;
        public float angle = 15f;
        public float radius = 0.5f;
        public Vector3 boxSize = Vector3.one;

        [Header("Over lifetime")]
        [Tooltip("Fade vertex colour alpha from 1 to 0 over the particle lifetime.")]
        public bool fadeAlpha = true;
        [Tooltip("Animate alpha from 0 to 1 instead (for shaders that clip(texture - alpha), e.g. TwoSidedDissolve).")]
        public bool invertAlpha = false;
        [Tooltip("Keep the start alpha during this first fraction of the lifetime.")]
        [Range(0f, 1f)] public float fadeStart = 0.2f;
        public float sizeStart = 1f;
        public float sizeEnd = 1f;

        private void Awake()
        {
            ParticleSystem ps = GetComponent<ParticleSystem>();
            if (ps == null) ps = gameObject.AddComponent<ParticleSystem>();
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            var main = ps.main;
            main.loop = true;
            main.startLifetime = new ParticleSystem.MinMaxCurve(lifetime.x, lifetime.y);
            main.startSpeed = new ParticleSystem.MinMaxCurve(speed.x, speed.y);
            main.startSize = new ParticleSystem.MinMaxCurve(size.x, size.y);
            main.startColor = startColor;
            main.gravityModifier = gravity;
            main.maxParticles = maxParticles;
            main.simulationSpace = worldSpace ? ParticleSystemSimulationSpace.World : ParticleSystemSimulationSpace.Local;
            main.startRotation = randomRotation ? new ParticleSystem.MinMaxCurve(0f, Mathf.PI * 2f) : new ParticleSystem.MinMaxCurve(0f);

            var emission = ps.emission;
            emission.enabled = true;
            emission.rateOverTime = rate;

            var sh = ps.shape;
            sh.enabled = true;
            switch (shape)
            {
                case Shape.Sphere: sh.shapeType = ParticleSystemShapeType.Sphere; break;
                case Shape.Circle: sh.shapeType = ParticleSystemShapeType.Circle; break;
                case Shape.Box: sh.shapeType = ParticleSystemShapeType.Box; sh.scale = boxSize; break;
                default: sh.shapeType = ParticleSystemShapeType.Cone; break;
            }
            sh.angle = angle;
            sh.radius = radius;

            var col = ps.colorOverLifetime;
            col.enabled = fadeAlpha;
            if (fadeAlpha)
            {
                var g = new Gradient();
                float a0 = invertAlpha ? 0f : 1f;
                g.SetKeys(
                    new[] { new GradientColorKey(Color.white, 0f), new GradientColorKey(Color.white, 1f) },
                    new[] { new GradientAlphaKey(a0, 0f), new GradientAlphaKey(a0, fadeStart), new GradientAlphaKey(1f - a0, 1f) });
                col.color = g;
            }

            var sol = ps.sizeOverLifetime;
            sol.enabled = !Mathf.Approximately(sizeStart, 1f) || !Mathf.Approximately(sizeEnd, 1f);
            sol.size = new ParticleSystem.MinMaxCurve(1f, AnimationCurve.Linear(0f, sizeStart, 1f, sizeEnd));

            var r = GetComponent<ParticleSystemRenderer>();
            r.sharedMaterial = material;
            r.renderMode = renderMode;
            if (renderMode == ParticleSystemRenderMode.Mesh && mesh != null) r.mesh = mesh;

            ps.Play();
        }
    }
}
