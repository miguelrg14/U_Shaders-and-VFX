# 36 · SDF icons

- **Demo scene:** `36_SDF-Icons.unity`

## Notes

Icons stored as signed distance fields (128x128 textures!): smoothstep(threshold, threshold + smoothness, distance) gives crisp edges at any scale, and the threshold grows/shrinks the shape (animated on the big icons). The shader is a UI shader (stencil + clip rect support) - use it on a UI Image; here it is shown on quads. Bottom: the raw distance field.

## Controls

Space: pause the threshold animation

## Files

- **Shaders/**: `SDFIcon.shader`
- **Materials/**: `M_SDF_Gear.mat`, `M_SDF_Heart.mat`, `M_SDF_Star.mat`, `M_SDF_Star_RawField.mat`
- **Textures/**: `T_SDF_Gear.png`, `T_SDF_Heart.png`, `T_SDF_Star.png`

## Implementation notes

-
