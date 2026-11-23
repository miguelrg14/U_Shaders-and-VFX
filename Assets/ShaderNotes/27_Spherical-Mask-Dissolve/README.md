# 27 · Spherical mask dissolve

- **Demo scene:** `27_Spherical-Mask-Dissolve.unity`

## Notes

SphereMaskController sends a global position/radius/softness (Shader.SetGlobal...) and every material with SphericalMaskDissolve clips the pixels outside that sphere, with an emissive noisy edge. Works in edit mode too: move the small sphere in the Scene view.

## Files

- **Shaders/**: `SphericalMaskDissolve.shader`
- **Scripts/**: `SphereMaskController.cs`
- **Materials/**: `M_SphericalMaskDissolve.mat`

## Implementation notes

-
