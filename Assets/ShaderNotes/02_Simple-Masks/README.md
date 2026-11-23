# 02 · Simple masks

- **Demo scene:** `02_Simple-Masks.unity`

## Notes

A texture is used as a mask: white areas show the inverted image, black areas the original one.
col = (1 - col) * mask + col * (1 - mask) is a lerp written by hand - the basic building block of masking.

## Controls

Tab / 1-9: switch effect variant · 0: effect off · Space: pause the animated parameter

## Files

- **Shaders/**: `MaskInvert.shader`
- **Materials/**: `M_MaskInvert.mat`

## Implementation notes

-
