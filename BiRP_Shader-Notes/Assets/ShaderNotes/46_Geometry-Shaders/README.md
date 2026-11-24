# 46 · Geometry shaders

- **Demo scene:** `46_Geometry-Shaders.unity`

## Notes

Introduction to geometry shaders: NewGeometryShader just re-emits each triangle (the template), and TrianglePyramidExtrusion turns every triangle into a pyramid by adding a vertex at the barycentre pushed along the normal (black at the base, white at the tip).

## Controls

Space: pause the extrusion animation

## Files

- **Shaders/**: `NewGeometryShader.shader`, `TrianglePyramidExtrusion.shader`
- **Materials/**: `M_NewGeometryShader.mat`, `M_TrianglePyramidExtrusion.mat`

## Implementation notes

-
