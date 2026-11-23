# 44 · Simple subsurface scattering

- **Demo scene:** `44_Subsurface-Scattering.unity`

## Notes

A cheap translucency term added to Standard lighting in a custom lighting function: light passing through the object is approximated with pow(saturate(dot(viewDir, -(lightDir + normal * distortion))), concentration), scaled by (1 - thickness). The light rotates and is behind the objects for part of the cycle - that is when the effect shows. Left: plain Standard for comparison.

## Files

- **Shaders/**: `SSSShader.shader`
- **Materials/**: `M_SSS_Jade.mat`, `M_SSS_Skin.mat`, `M_SSS_Wax.mat`
- **Textures/**: `T_Thickness.png`

## Implementation notes

-
