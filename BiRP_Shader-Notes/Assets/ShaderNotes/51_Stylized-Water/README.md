# 51 · Stylized water shader

- **Demo scene:** `51_Stylized-Water.unity`

## Notes

Stylised water: colour, fog and foam lines come from the difference between the scene depth and the water depth, two panning normal maps add detail, and fresnel drives transparency. Interactive ripples: particles on a dedicated layer (WaterRipples) are rendered by an orthographic top-down camera into a RenderTexture, which the water samples in world space to offset its normals and remove foam.

## Controls

Press Play to see the boat ripples

## Files

- **Shaders/**: `StylizedWater.shader`, `WaterRipples.shader`
- **Scripts/**: `StylizedWaterRippleSetup.cs`, `WaterRippleCamera.cs`
- **Materials/**: `M_StylizedWater.mat`, `M_WaterRipples.mat`
- **Textures/**: `T_Ripple_Normal.png`

## Implementation notes

- `StylizedWaterRippleSetup.cs` creates the RenderTexture at runtime and wires it to the ripple camera and the water material.
