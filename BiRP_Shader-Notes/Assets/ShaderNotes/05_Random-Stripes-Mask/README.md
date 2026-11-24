# 05 · Random stripes mask

- **Demo scene:** `05_Random-Stripes-Mask.unity`

## Notes

floor(uv.y * frequency) gives an id per horizontal band; feeding it to a hash (frac(sin(dot(...)))) gives a random value per band, and step(fill, random) turns it into a stripe mask. Used by the glitch effect.

## Controls

Tab / 1-9: switch effect variant · 0: effect off · Space: pause the animated parameter

## Files

- **Shaders/**: `StripesMaskShader.shader`
- **Materials/**: `M_StripesMask.mat`

## Implementation notes

-
