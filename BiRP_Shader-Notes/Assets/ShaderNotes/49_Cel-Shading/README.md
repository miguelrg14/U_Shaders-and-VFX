# 49 · Cel shading

- **Demo scene:** `49_Cel-Shading.unity`

## Notes

A custom lighting function for toon shading: N·L is divided by a cutoff and rounded into bands, the shadow attenuation is rounded too, specular is a hard step on the reflection vector, and a rim term (optionally affected by shadows via a shader_feature) is added. The light rotates.

## Files

- **Shaders/**: `CelShaded.shader`
- **Materials/**: `M_Cel_1Band_Rim.mat`, `M_Cel_2Bands_ShadowedRim.mat`, `M_Cel_3Bands_Specular.mat`, `M_Cel_Ground.mat`, `M_Cel_Textured.mat`

## Implementation notes

-
