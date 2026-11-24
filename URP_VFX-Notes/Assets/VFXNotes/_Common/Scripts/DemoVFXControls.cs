using UnityEngine;
using UnityEngine.VFX;

namespace VFXNotes
{
    /// <summary>
    /// Play-mode controls for every VisualEffect in the scene.
    /// R = restart, Space = pause / resume, E = send the "OnPlay" event, F = toggle slow motion.
    /// </summary>
    public class DemoVFXControls : MonoBehaviour
    {
        [Range(0.05f, 1f)] public float slowMotionRate = 0.2f;

        private bool paused;
        private bool slowMotion;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                foreach (VisualEffect vfx in Effects()) vfx.Reinit();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                paused = !paused;
                foreach (VisualEffect vfx in Effects()) vfx.pause = paused;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach (VisualEffect vfx in Effects()) vfx.SendEvent("OnPlay");
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                slowMotion = !slowMotion;
                foreach (VisualEffect vfx in Effects()) vfx.playRate = slowMotion ? slowMotionRate : 1f;
            }
        }

        private static VisualEffect[] Effects()
        {
            return FindObjectsByType<VisualEffect>(FindObjectsSortMode.None);
        }
    }
}
