# 24 · Edge detection image effect

- **Demo scene:** `24_Edge-Detection.unity`

## Notes

Edges from _CameraDepthNormalsTexture: each pixel's (normal, depth) is compared with the average of its 8 neighbours; if the difference is above _Threshold the edge colour is drawn.

## Controls

Tab / 1-9: switch effect variant · 0: effect off · Space: pause the animated parameter

## Files

- **Shaders/**: `EdgeDetectionShader.shader`
- **Materials/**: `M_EdgeDetection.mat`, `M_EdgeDetection_White.mat`

## Implementation notes

-
