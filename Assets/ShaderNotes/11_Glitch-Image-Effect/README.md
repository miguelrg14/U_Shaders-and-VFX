# 11 · Glitch image effect

- **Demo scene:** `11_Glitch-Image-Effect.unity`

## Notes

Combines the previous effects: random stripe masks displace bands of the image left/right, a wavy displacement adds wobble and chromatic aberration splits the channels. frac(_GlitchEffect) sequences the parts, so animating that single value from 0 to 1 plays a glitch burst.

## Controls

Tab / 1-9: switch effect variant · 0: effect off · Space: pause the animated parameter

## Files

- **Shaders/**: `GlitchEffectShader.shader`
- **Materials/**: `M_GlitchEffect.mat`

## Implementation notes

-
