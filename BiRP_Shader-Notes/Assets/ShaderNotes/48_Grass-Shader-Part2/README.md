# 48 · Grass shader (part 2)

- **Demo scene:** `48_Grass-Shader-Part2.unity`

## Notes

Part 2 adds tessellation (more triangles = more blades), lighting with shadows (a ForwardBase pass with SHADOW_ATTENUATION and a ShadowCaster pass), translucency/rim, and trampling: GrassTramplePosition.cs sends a position + radius and blade tips are pushed away from it.
Note: the trample script writes into the material asset every frame (by design).

## Files

- **Shaders/**: `CustomTessellation.cginc`, `GrassGeometryShader.shader`
- **Scripts/**: `GrassTramplePosition.cs`
- **Materials/**: `M_GrassLit.mat`

## Implementation notes

- `GrassGeometryShader.shader`: `Autolight.cginc` → `AutoLight.cginc` (correct casing for case-sensitive file systems).
- `CustomTessellation.cginc` implements the minimal hull/domain stages the grass shader needs (uniform tessellation via `_TessellationUniform`).
