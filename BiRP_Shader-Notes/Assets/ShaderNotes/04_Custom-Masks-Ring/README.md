# 04 · Custom masks: ring mask

- **Demo scene:** `04_Custom-Masks-Ring.unity`

## Notes

Same idea as the disc mask, but using abs(distance - ringCentre) / thickness to get a ring. This mask is reused later by the shockwave effect.

## Controls

Tab / 1-9: switch effect variant · 0: effect off · Space: pause the animated parameter

## Files

- **Shaders/**: `RingMask.shader`
- **Materials/**: `M_RingMask.mat`

## Implementation notes

-
