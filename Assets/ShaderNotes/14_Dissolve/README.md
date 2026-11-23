# 14 · Dissolve shader

- **Demo scene:** `14_Dissolve.unity`

## Notes

Classic dissolve: clip(sliceGuide - _SliceAmount) discards pixels following a noise texture. Pixels that are about to be clipped (test < _BurnSize) get emission from a burn ramp texture.

## Controls

Space: pause the dissolve animation

## Files

- **Shaders/**: `Dissolve.shader`
- **Materials/**: `M_Dissolve.mat`

## Implementation notes

-
