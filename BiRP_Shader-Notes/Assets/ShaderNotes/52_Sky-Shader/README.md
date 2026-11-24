# 52 · Sky shader

- **Demo scene:** `52_Sky-Shader.unity`

## Notes

A procedural skybox shader: three-colour vertical gradient, sun and moon (with phase) placed with _WorldSpaceLightPos0, stars that only show at night, and panning clouds with silver lining. SkyController.cs evaluates gradients from the sun's angle to drive the sky, sun, light, ambient and cloud colours - the directional light rotates to play a full day/night cycle.
Tip: enable 'Use Srub' on the light to scrub the cycle from the inspector.

## Files

- **Shaders/**: `SkyShader.shader`
- **Scripts/**: `SkyController.cs`
- **Materials/**: `M_Sky.mat`
- **Textures/**: `T_Stars.png`

## Implementation notes

-
