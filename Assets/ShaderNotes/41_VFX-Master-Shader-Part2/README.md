# 41 · VFX master shader (part 2)

- **Demo scene:** `41_VFX-Master-Shader-Part2.unity`

## Notes

Part 2 adds a secondary texture, colour banding, polar coordinates, a circle mask, a cull-mode enum and - most importantly - uses the vertex colour alpha to increase the cutoff, so particle systems can dissolve particles over their lifetime. (DemoProceduralMesh gives the meshes explicit white vertex colours.)

## Controls

Press Play to see the particles

## Files

- **Shaders/**: `VFXMasterShader.shader`
- **Materials/**: `M_VFX2_DissolveParticles.mat`, `M_VFX2_Portal.mat`, `M_VFX2_ToonFireball.mat`

## Implementation notes

-
