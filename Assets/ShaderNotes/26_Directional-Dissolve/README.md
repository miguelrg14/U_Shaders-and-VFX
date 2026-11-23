# 26 · Directional dissolve

- **Demo scene:** `26_Directional-Dissolve.unity`

## Notes

Dissolve along a world-space direction: the clip test is dot(worldPos, _Direction). A band near the cut gets emission, broken up by random squares (hash of floor(uv * _NoiseSize)).

## Controls

Space: pause the animation

## Files

- **Shaders/**: `DirectionalDissolve.shader`
- **Materials/**: `M_DirectionalDissolve_Diagonal.mat`, `M_DirectionalDissolve_Up.mat`

## Implementation notes

-
