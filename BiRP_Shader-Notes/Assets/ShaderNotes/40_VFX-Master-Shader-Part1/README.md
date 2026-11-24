# 40 · VFX master shader (part 1): apprentice

- **Demo scene:** `40_VFX-Master-Shader-Part1.unity`

## Notes

The first version of an all-in-one VFX shader: a grayscale texture is panned and displaced, contrast and power shape it, a gradient map colours it, a cutoff clips it with a burn edge, and an optional vertex offset (shader_feature toggle) pushes vertices along their normals.

## Controls

Space: pause the cutoff animations

## Files

- **Shaders/**: `VFXApprenticeShader.shader`
- **Materials/**: `M_VFX1_EnergyOrb.mat`, `M_VFX1_FirePillar.mat`, `M_VFX1_ToxicPool.mat`

## Implementation notes

-
