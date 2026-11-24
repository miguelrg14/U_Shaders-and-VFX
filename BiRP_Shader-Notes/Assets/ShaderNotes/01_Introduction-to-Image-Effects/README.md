# 01 · Introduction to image effects

- **Demo scene:** `01_Introduction-to-Image-Effects.unity`

## Notes

The first image effect: a script with OnRenderImage calls Graphics.Blit(src, dest, material), which draws a full-screen quad with the material. The shader receives the rendered frame as _MainTex and returns 1 - colour.

Study: CustomImageEffect.cs (reused by most image-effect demos) and InvertColor.shader.

## Controls

Tab / 1-9: switch effect variant · 0: effect off · Space: pause the animated parameter

## Files

- **Shaders/**: `InvertColor.shader`
- **Scripts/**: `CustomImageEffect.cs`
- **Materials/**: `M_InvertColor.mat`

## Implementation notes

- `InvertColor.shader`: `mul(UNITY_MATRIX_MVP, v)` replaced by `UnityObjectToClipPos(v)` (the same upgrade Unity applies automatically on import).
