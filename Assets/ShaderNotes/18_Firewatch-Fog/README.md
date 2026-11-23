# 18 · Firewatch multi-coloured fog

- **Demo scene:** `18_Firewatch-Fog.unity`

## Notes

Fog coloured by a gradient texture indexed with the scene depth (Linear01Depth of _CameraDepthTexture), inspired by Firewatch. The ramp's alpha controls how much fog is applied at each distance; the sky (depth = 1) is left untouched.

## Controls

Tab / 1-9: switch effect variant · 0: effect off · Space: pause the animated parameter

## Files

- **Shaders/**: `FirewatchFog.shader`
- **Materials/**: `M_FirewatchFog.mat`
- **Textures/**: `T_FogRamp_Firewatch.png`

## Implementation notes

-
