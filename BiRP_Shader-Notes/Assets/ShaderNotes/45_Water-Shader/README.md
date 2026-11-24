# 45 · Water shader

- **Demo scene:** `45_Water-Shader.unity`

## Notes

A transparent, tessellated surface shader: two noise textures displace the vertices (normals are rebuilt from two neighbour samples), the wave height indexes a gradient map, and the depth texture gives shore colour, foam lines and soft transparency near the sand. On the right: the older NormalDisplacement water material.

## Files

- **Shaders/**: `NormalDisplacement.shader`, `WaterShader.shader`
- **Materials/**: `M_NormalDisplacement.mat`, `M_Sand.mat`, `M_Water.mat`
- **Textures/**: `T_Displacements.png`, `T_Foam.png`, `T_Sand_Albedo.png`

## Implementation notes

- An older water material with normal-map displacement is included as well: `NormalDisplacement.shader` and its displacement guide texture, with a procedural water normal map.
