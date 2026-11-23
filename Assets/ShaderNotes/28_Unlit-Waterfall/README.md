# 28 · Unlit waterfall

- **Demo scene:** `28_Unlit-Waterfall.unity`

## Notes

Three unlit shaders: the waterfall uses a scrolling, posterised noise (round(noise * 5) / 5) to blend two vertical gradients, plus a foam line at the bottom; the pool compares the scene depth with its own depth to draw white foam where it intersects objects; the foam particles use a two-sided dissolve driven by the particle colour alpha (two passes: front colour and back colour with Cull Front).

## Controls

Press Play to see the foam particles

## Files

- **Shaders/**: `TwoSidedDissolve.shader`, `WaterIntersection.shader`, `WaterfallShader.shader`
- **Materials/**: `M_TwoSidedDissolve_Foam.mat`, `M_WaterIntersection.mat`, `M_Waterfall.mat`

## Implementation notes

- `TwoSidedDissolve.shader`: `UNITY_APPLY_FOG` used an undeclared `col` variable (compile error as soon as fog is enabled); `col` is now declared in both passes.
