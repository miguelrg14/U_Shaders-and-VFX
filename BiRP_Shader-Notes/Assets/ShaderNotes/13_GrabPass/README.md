# 13 · GrabPass

- **Demo scene:** `13_GrabPass.unity`

## Notes

GrabPass copies what has been rendered so far into _GrabTexture. A transparent object can then sample the screen behind it (ComputeGrabScreenPos + tex2Dproj) - here to invert it. This is the basis of refraction/distortion shaders (see 43 · GrabPass distortion).

## Files

- **Shaders/**: `GrabPassInvertColors.shader`
- **Materials/**: `M_GrabPassInvertColors.mat`

## Implementation notes

-
