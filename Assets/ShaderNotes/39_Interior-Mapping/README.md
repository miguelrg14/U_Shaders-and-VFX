# 39 · Interior mapping

- **Demo scene:** `39_Interior-Mapping.unity`

## Notes

Fake rooms behind windows: per window tile, a ray from the camera (in tangent space) is intersected with an imaginary box and the hit point samples a cubemap. The window mask decides where the room replaces the facade. Tiling the cubemap property sets how many rooms per face. Orbit around the building.

## Files

- **Shaders/**: `InteriorMappingSurface.shader`
- **Materials/**: `M_InteriorMapping.mat`, `M_InteriorMapping_Small.mat`
- **Textures/**: `T_Facade_Albedo.png`, `T_Facade_WindowMask.png`, `T_Room_Cubemap.png`

## Implementation notes

-
