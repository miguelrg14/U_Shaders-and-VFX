# 34 · Surface shader: custom lighting override

- **Demo scene:** `34_Surface-Shader-Lighting.unity`

## Notes

How to write your own lighting function in a surface shader (LightingX + LightingX_GI) while still calling Unity's PBS LightingStandard. Back row: Standard shader; front row: SurfaceShaderOverride with identical values - they should look the same, which proves the override is a correct starting point for custom lighting (used later by the SSS and cel-shading notes).

## Files

- **Shaders/**: `SurfaceShaderOverride.shader`
- **Materials/**: `M_Override_0.mat`, `M_Override_1.mat`, `M_Override_2.mat`, `M_Override_3.mat`, `M_Standard_0.mat`, `M_Standard_1.mat`, `M_Standard_2.mat`, `M_Standard_3.mat`

## Implementation notes

-
