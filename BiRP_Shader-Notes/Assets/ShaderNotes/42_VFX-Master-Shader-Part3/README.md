# 42 · VFX master shader (part 3): transparent

- **Demo scene:** `42_VFX-Master-Shader-Part3.unity`

## Notes

The transparent version: alpha blending with a soft cutoff, soft particles (fade where the effect intersects opaque geometry, using the depth texture) and a rectangle mask to hide quad edges. The shield is half-buried in the ground to show the soft intersection.

## Controls

Press Play to see the flame particles

## Files

- **Shaders/**: `VFXMasterShaderTransparent.shader`
- **Materials/**: `M_VFX3_Beam.mat`, `M_VFX3_Flames.mat`, `M_VFX3_MagicCircle.mat`, `M_VFX3_Shield.mat`

## Implementation notes

-
