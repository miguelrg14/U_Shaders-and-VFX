using UnityEngine;

/// <summary>
/// Demo helper: creates the ripple RenderTexture at runtime and
/// connects it to the orthographic ripple camera and to the water material (_RenderTexture).
/// A half-float format is used because the ripple shader writes signed normal vectors.
/// </summary>
public class StylizedWaterRippleSetup : MonoBehaviour
{
    public Camera rippleCamera;
    public Material waterMaterial;
    public int resolution = 512;

    private RenderTexture renderTexture;

    private void OnEnable()
    {
        if (rippleCamera == null || waterMaterial == null) return;
        renderTexture = new RenderTexture(resolution, resolution, 0, RenderTextureFormat.ARGBHalf)
        {
            name = "WaterRipplesRT",
            wrapMode = TextureWrapMode.Clamp
        };
        renderTexture.Create();
        rippleCamera.targetTexture = renderTexture;
        waterMaterial.SetTexture("_RenderTexture", renderTexture);
    }

    private void OnDisable()
    {
        if (rippleCamera != null) rippleCamera.targetTexture = null;
        if (waterMaterial != null) waterMaterial.SetTexture("_RenderTexture", null);
        if (renderTexture != null)
        {
            renderTexture.Release();
            Destroy(renderTexture);
            renderTexture = null;
        }
    }
}
