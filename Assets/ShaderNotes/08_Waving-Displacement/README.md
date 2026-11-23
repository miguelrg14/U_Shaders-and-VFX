# 08 · Waving displacement

- **Demo scene:** `08_Waving-Displacement.unity`

## Notes

The displacement texture is scrolled with _Time and remapped from [0,1] to [-1,1] (displ * 2 - 1) so the image waves in every direction - a heat-haze / underwater look.

## Controls

Tab / 1-9: switch effect variant · 0: effect off · Space: pause the animated parameter

## Files

- **Shaders/**: `DisplacementImageEffect.shader`
- **Materials/**: `M_DisplacementImageEffect.mat`

## Implementation notes

-
