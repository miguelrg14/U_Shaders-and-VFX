# 30 · Teleportation dissolve

- **Demo scene:** `30_Teleportation-Dissolve.unity`

## Notes

A dissolve for teleporting: pixels are clipped in random squares from the bottom up, and in the vertex function the vertices that are about to disappear are pushed along _Direction, so pieces fly away. The material disables batching because world positions are needed per object.

## Controls

Space: pause the animation

## Files

- **Shaders/**: `TeleportationDissolve.shader`
- **Materials/**: `M_TeleportationDissolve.mat`

## Implementation notes

-
