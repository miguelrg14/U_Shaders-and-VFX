# 22 · Snow shader

- **Demo scene:** `22_Snow.unity`

## Notes

Snow is placed where the world-space normal (WorldNormalVector with INTERNAL_DATA, so normal maps are taken into account) faces _SnowDirection: step(_SnowLevel, dot(normal, direction)) blends albedo, normals, smoothness and metallic between rock and snow.

## Controls

Space: pause the snow level animation

## Files

- **Shaders/**: `SnowShader.shader`
- **Materials/**: `M_Snow.mat`
- **Textures/**: `T_Snow_Albedo.png`, `T_Snow_Normal.png`

## Implementation notes

-
