# 47 · Grass shader (part 1)

- **Demo scene:** `47_Grass-Shader-Part1.unity`

## Notes

A geometry shader that spawns grass blades (one triangle each) at random barycentric positions on every triangle of the mesh. Height comes from a noise texture, sway from a scrolling wind texture, colour from a gradient map, and the blade count drops with camera distance. Zoom out to see the LOD.

## Files

- **Shaders/**: `GrassGeometryShaderUnlit.shader`
- **Materials/**: `M_GrassUnlit.mat`

## Implementation notes

-
