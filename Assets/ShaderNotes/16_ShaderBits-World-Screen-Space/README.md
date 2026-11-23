# 16 · Shader bits: world space & screen space

- **Demo scene:** `16_ShaderBits-World-Screen-Space.unity`

## Notes

Complete shaders built around small code snippets. From left to right: texture projected in world space (surface shader), world-space grid (vertex/fragment), texture in screen space (surface) and screen space (vertex/fragment).
Watch how world-space patterns stay still while the objects move, and screen-space ones stick to the screen.

## Files

- **Shaders/**: `ScreenSpace_Surface.shader`, `ScreenSpace_VertFrag.shader`, `WorldSpace_Surface.shader`, `WorldSpace_VertFrag.shader`
- **Snippets/**: `shader-bits-surface.txt`, `shader-bits-vertex-fragment.txt`
- **Materials/**: `M_ScreenSpace_Surface.mat`, `M_ScreenSpace_VertFrag.mat`, `M_WorldSpace_Surface.mat`, `M_WorldSpace_VertFrag.mat`

## Implementation notes

- The base code is only *snippets* (not compilable shaders). They are kept in `Snippets/` as `.txt`, and complete shaders that use each snippet are in `Shaders/`.
