# 21 · Directional colouring

- **Demo scene:** `21_Directional-Coloring.unity`

## Notes

Unlit colouring from the dot product between the normal and the light direction: front row = smooth 3-colour gradient (DirectionalColoring), back row = hard cel bands with two thresholds (DirectionalCelColoring). The directional light rotates to show the effect.

Note: the shader maps dot > 0 (facing the light) to _DarkColor, so the material puts the bright colour in _DarkColor and the dark one in _LightColor.

## Files

- **Shaders/**: `DirectionalCelColoring.shader`, `DirectionalColoring.shader`
- **Materials/**: `M_DirectionalCelColoring.mat`, `M_DirectionalColoring.mat`

## Implementation notes

- `DirectionalCelColoring.shader`: Added `Tags { "LightMode"="ForwardBase" }` to the pass so `_WorldSpaceLightPos0` is reliably set in the Built-in forward renderer.
- `DirectionalColoring.shader`: Added `Tags { "LightMode"="ForwardBase" }` to the pass so `_WorldSpaceLightPos0` is reliably set in the Built-in forward renderer.
