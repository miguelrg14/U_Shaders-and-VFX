# 03 · Custom masks: disc mask

- **Demo scene:** `03_Custom-Masks-Disc.unity`

## Notes

A procedural mask built from the distance to a centre point. SizeX/SizeY compensate the screen aspect ratio, Hardness controls the falloff (pow) and Invert flips/scales the result.

Note: the shader returns (orCol.rgb, a * orCol.a) - the comma operator keeps only the last value, so the output is the mask itself in grayscale, which is the mask preview.

## Controls

Tab / 1-9: switch effect variant · 0: effect off · Space: pause the animated parameter

## Files

- **Shaders/**: `DiscMask.shader`
- **Materials/**: `M_DiscMask.mat`, `M_DiscMask_Inverted.mat`

## Implementation notes

-
