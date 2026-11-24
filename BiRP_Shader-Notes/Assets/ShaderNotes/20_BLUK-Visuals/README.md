# 20 · BLUK visuals (2D fog & parallax)

- **Demo scene:** `20_BLUK-Visuals.unity`

## Notes

2D atmosphere from BLUK: sprites are tinted towards the sky colour by their distance to the camera (plus a vertical gradient), and ParallaxingScript moves the camera's child layers by an amount based on their depth, which fakes parallax with an orthographic camera. SkyColorManager keeps the camera background and the fog colour in sync.

## Controls

A / D or arrow keys: move the camera (it drifts on its own when idle)

## Files

- **Shaders/**: `2DFogSpriteShader.shader`
- **Scripts/**: `ParallaxingScript.cs`, `SkyColorManager.cs`
- **Materials/**: `M_2DFogSprite.mat`
- **Textures/**: `S_Layer0.png`, `S_Layer1.png`, `S_Layer2.png`, `S_Layer3.png`, `S_Layer4.png`

## Implementation notes

- `2DFogSpriteShader.shader`: `mul(UNITY_MATRIX_MVP, v)` replaced by `UnityObjectToClipPos(v)` (the same upgrade Unity applies automatically on import).
- `ParallaxingScript.cs`: Added the missing `using UnityEngine;` (the code did not compile on its own).
- `SkyColorManager.cs`: Added the missing `using UnityEngine;` (the code did not compile on its own).
