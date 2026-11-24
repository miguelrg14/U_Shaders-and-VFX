# 17 · Shader bits: camera distance, view direction & normals

- **Demo scene:** `17_ShaderBits-Distance-ViewDir-Normals.unity`

## Notes

Snippets turned into shaders: left row of cubes = colour by camera distance (surface), right row = the same in vertex/fragment; centre spheres = rim/fresnel from the view direction (surface and vertex/fragment); capsule and back sphere = world normals shown as colours.
Zoom in/out to see the distance colouring change.

## Files

- **Shaders/**: `CameraDistance_Surface.shader`, `CameraDistance_VertFrag.shader`, `Normals_VertFrag.shader`, `ViewDirection_Surface.shader`, `ViewDirection_VertFrag.shader`
- **Snippets/**: `shader_bits_surface.txt`, `shader_bits_vertex_fragment.txt`
- **Materials/**: `M_CameraDistance_Surface.mat`, `M_CameraDistance_VertFrag.mat`, `M_Normals_VertFrag.mat`, `M_ViewDirection_Surface.mat`, `M_ViewDirection_VertFrag.mat`

## Implementation notes

- The base code is only *snippets* (not compilable shaders; one has a missing parenthesis). They are kept in `Snippets/` as `.txt`, and complete shaders that use each snippet are in `Shaders/`.
