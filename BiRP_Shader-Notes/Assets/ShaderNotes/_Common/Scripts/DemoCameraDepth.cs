using UnityEngine;

namespace ShaderStudy
{
    /// <summary>
    /// Makes the camera render _CameraDepthTexture and/or _CameraDepthNormalsTexture.
    /// In the Built-in pipeline (forward) these textures are only guaranteed when a script asks for them.
    /// </summary>
    [ExecuteAlways]
    [RequireComponent(typeof(Camera))]
    public class DemoCameraDepth : MonoBehaviour
    {
        public DepthTextureMode mode = DepthTextureMode.Depth;

        private void OnEnable()
        {
            GetComponent<Camera>().depthTextureMode |= mode;
        }

        private void OnValidate()
        {
            GetComponent<Camera>().depthTextureMode |= mode;
        }
    }
}
