# 29 · Vertical fog (intersection)

- **Demo scene:** `29_Vertical-Fog.unity`

## Notes

A transparent plane whose opacity grows with the distance between its own depth and the scene depth behind it (smootherstep of the intersection). Where the ground is far below, the plane is opaque, so valleys fill with fog while hill tops poke through. The plane moves up and down slowly.

## Files

- **Shaders/**: `VerticalFogIntersection.shader`
- **Materials/**: `M_VerticalFog.mat`

## Implementation notes

-
