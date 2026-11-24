# VFX notes (URP · VFX Graph)

Real-time VFX made with Unity's VFX Graph, one folder and one scene per effect.

## Workflow

1. `effects.txt` lists the effects (`NN | Folder-Name | Title`).
2. **Tools > VFX Notes > 2. Create missing effect scenes** creates, for every new line, the folder
   (`Textures/`, `Materials/`, `Shaders/`, `VFX/`), a README template and a scene with camera, light, ground,
   global post-processing volume (bloom, ACES tonemapping, vignette), an empty `VFX` object and the demo panel.
   It also updates the Build Settings (menu first).
3. Build the graph in `VFX/`, assign it to the `VFX` object and fill in the README.

The URP asset, renderer and post-processing profile are created automatically the first time the project is
opened (also available as **Tools > VFX Notes > 1. Setup URP and post-processing**).

## Shared textures (`_Common/Textures`)

Particle shapes (soft/hard circle, glow, spark, flare, rings, slash arc, trail, lightning), a 4x4 smoke flipbook,
tileable noises (Perlin, clouds, Voronoi, RG displacement) and gradient ramps (fire, magic, toxic, ice).
All generated procedurally.

## Controls (Play mode)

R restart · Space pause · E send `OnPlay` · F slow motion · right mouse orbit · wheel zoom ·
N / B next / previous effect · M menu · H hide the panel.
