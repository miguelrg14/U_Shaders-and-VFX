# 32 · Spherical mask post-processing effect

- **Demo scene:** `32_Spherical-Mask-PostProcess.unity`

## Notes

Post-processing that keeps colour only inside a world-space sphere and turns the rest grayscale. The world position of each pixel is reconstructed from the depth texture and a per-pixel ray (the script builds a clip-to-world matrix). In the Scene view you can drag the sphere handle (custom editor in SphericalMaskPPController.cs).

## Files

- **Shaders/**: `SphericalMaskPP.shader`
- **Scripts/**: `SphericalMaskPPController.cs`, `SphericalMaskPPFollow.cs`
- **Materials/**: `M_SphericalMaskPP.mat`

## Implementation notes

- `SphericalMaskPPFollow.cs` moves the mask centre with a scene object so the effect animates in Play mode.
