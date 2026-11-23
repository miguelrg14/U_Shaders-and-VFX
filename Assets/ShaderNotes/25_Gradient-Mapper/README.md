# 25 · Gradient mapper

- **Demo scene:** `25_Gradient-Mapper.unity`

## Notes

Gradient mapping: the sprite's grayscale value is used as the U coordinate of a gradient texture. GradientMapper.cs bakes a Unity Gradient into such a texture: enable 'testing' on a sprite to edit its gradient live, and press 'Make Gradient Map' in its inspector to save it as a PNG in Assets/GradientMaps.
Left column: original grayscale sprites.

## Files

- **Shaders/**: `SpriteGradientMap.shader`
- **Scripts/**: `GradientMapper.cs`
- **Materials/**: `M_GradientMap_Flame_Ice.mat`, `M_GradientMap_Flame_Sunset.mat`, `M_GradientMap_Flame_Toxic.mat`, `M_GradientMap_Planet_Ice.mat`, `M_GradientMap_Planet_Sunset.mat`, `M_GradientMap_Planet_Toxic.mat`
- **Textures/**: `S_Flame_Grayscale.png`, `S_Planet_Grayscale.png`, `T_GradientMap_Ice.png`, `T_GradientMap_Sunset.png`, `T_GradientMap_Toxic.png`

## Implementation notes

-
