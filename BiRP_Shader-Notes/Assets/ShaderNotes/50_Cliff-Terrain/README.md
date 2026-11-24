# 50 · Cliff terrain shader

- **Demo scene:** `50_Cliff-Terrain.unity`

## Notes

Terrain shader that automatically puts a tri-planar cliff texture on steep slopes (world-normal threshold) on top of the usual 4-layer splat map. The demo builds a terraced height field to get plenty of cliffs; CliffTerrainDemo.cs fills the terrain properties (_Control, _Splat0-3...) that Unity's Terrain would normally provide.

## Files

- **Shaders/**: `CliffTerrainShader.shader`
- **Scripts/**: `CliffTerrainDemo.cs`
- **Materials/**: `M_CliffTerrain.mat`
- **Textures/**: `T_Dirt_Albedo.png`, `T_Dirt_Normal.png`, `T_Grass_Albedo.png`, `T_Grass_Normal.png`, `T_Sand_Albedo.png`, `T_Sand_Normal.png`, `T_Snow_Albedo.png`, `T_Snow_Normal.png`

## Implementation notes

- The shader is meant to be used as a **Terrain** material (Unity's terrain system fills `_Control`, `_Splat0-3`, `_Normal0-3`...). To keep the demo self-contained, `CliffTerrainDemo.cs` builds a procedural height-field mesh and feeds exactly those properties through a MaterialPropertyBlock. Assign the material to a real Terrain's *Material* slot to use it as intended.
