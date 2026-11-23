using UnityEngine;

/// <summary>
/// Demo helper: copies a transform's position into
/// SphericalMaskPPController.spherePosition so the mask can be animated or moved in the scene.
/// </summary>
[ExecuteInEditMode]
public class SphericalMaskPPFollow : MonoBehaviour
{
    public SphericalMaskPPController controller;
    public Transform target;

    private void Update()
    {
        if (controller != null && target != null)
        {
            controller.spherePosition = target.position;
        }
    }
}
