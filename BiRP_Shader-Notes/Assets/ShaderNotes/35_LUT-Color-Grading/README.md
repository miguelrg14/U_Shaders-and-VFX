# 35 · LUT colour grading

- **Demo scene:** `35_LUT-Color-Grading.unity`

## Notes

Colour grading with a 32x32x32 lookup table stored as a 1024x32 strip: blue picks the 32x32 cell, red and green index inside it. The LUTs were generated procedurally (Neutral must look identical to the original image). Make your own by grading LUT_Neutral.png in any image editor.

## Controls

Tab / 1-9: switch effect variant · 0: effect off · Space: pause the animated parameter

## Files

- **Shaders/**: `LUTColorGrading.shader`
- **Materials/**: `M_LUT_Cold.mat`, `M_LUT_Neutral.mat`, `M_LUT_Noir.mat`, `M_LUT_Sepia.mat`, `M_LUT_TealOrange.mat`, `M_LUT_Warm.mat`
- **Textures/**: `LUT_Cold.png`, `LUT_Neutral.png`, `LUT_Noir.png`, `LUT_Sepia.png`, `LUT_TealOrange.png`, `LUT_Warm.png`

## Implementation notes

-
