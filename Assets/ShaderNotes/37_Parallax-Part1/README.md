# 37 · Parallax effect (part 1)

- **Demo scene:** `37_Parallax-Part1.unity`

## Notes

Parallax mapping with Unity's ParallaxOffset(height, amount, viewDir): the UVs are shifted along the tangent-space view direction according to a height map, so bricks seem to have depth. Left: normal map only; right: parallax (amount animated). Orbit to grazing angles to compare.

## Controls

Space: pause the parallax amount animation

## Files

- **Shaders/**: `ParallaxShader.shader`
- **Materials/**: `M_Bricks_NoParallax.mat`, `M_Parallax.mat`
- **Textures/**: `T_Bricks_Albedo.png`, `T_Bricks_Height.png`, `T_Bricks_Normal.png`

## Implementation notes

-
