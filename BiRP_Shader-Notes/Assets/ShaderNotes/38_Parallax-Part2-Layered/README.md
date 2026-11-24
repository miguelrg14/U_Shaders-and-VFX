# 38 · Parallax effect (part 2): layered parallax

- **Demo scene:** `38_Parallax-Part2-Layered.unity`

## Notes

Layered parallax: the same texture is sampled N times, each time offset further along the tangent-space view direction and with less intensity, and the results are added to the albedo. It fakes glowing layers 'inside' the surface. Orbit around to see the layers slide.

## Files

- **Shaders/**: `LayeredParallax.shader`
- **Materials/**: `M_LayeredParallax.mat`
- **Textures/**: `T_DarkStone_Albedo.png`, `T_Runes.png`

## Implementation notes

-
