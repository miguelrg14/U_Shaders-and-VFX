# 43 · GrabPass distortion

- **Demo scene:** `43_GrabPass-Distortion.unity`

## Notes

GrabPass + a normal map: the grab-screen UVs are offset by the normal map's XY, masked by a radial texture and by the particle colour alpha, giving heat haze or refraction. Used on rising particles above the 'fire' and on a moving quad.

## Controls

Press Play to see the heat-haze particles

## Files

- **Shaders/**: `GrabPassDistortion.shader`
- **Materials/**: `M_GrabPassDistortion.mat`

## Implementation notes

-
