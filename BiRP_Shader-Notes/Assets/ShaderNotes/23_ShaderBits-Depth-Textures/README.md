# 23 · Shader bits: camera depth textures

- **Demo scene:** `23_ShaderBits-Depth-Textures.unity`

## Notes

How to read the camera depth textures in the Built-in pipeline: SAMPLE_DEPTH_TEXTURE + LinearEyeDepth (distance in world units), tex2Dproj + Linear01Depth (0 at camera, 1 at far plane) and DecodeDepthNormal on _CameraDepthNormalsTexture. DemoCameraDepth.cs enables both textures on the camera.

## Controls

Tab / 1-9: switch effect variant · 0: effect off · Space: pause the animated parameter

## Files

- **Shaders/**: `DepthNormals.shader`, `Linear01Depth.shader`, `LinearEyeDepth.shader`
- **Snippets/**: `shader-bits-camera-depth-textures.txt`
- **Materials/**: `M_DepthNormals.mat`, `M_Linear01Depth.mat`, `M_LinearEyeDepth.mat`

## Implementation notes

- The base code is only *snippets* (not compilable shaders). They are kept in `Snippets/` as `.txt`, and three complete image-effect shaders that visualise each depth texture are in `Shaders/`.
