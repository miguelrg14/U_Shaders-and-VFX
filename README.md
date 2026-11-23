# U_Shaders-and-VFX

Personal study library of shaders and VFX in Unity.

## Shader notes (Built-in Render Pipeline)

Notes and experiments on shaders, image effects and VFX techniques, each one with its own **demo scene**,
materials and a README.

- **Unity:** 6000.6.8f1, **Built-in Render Pipeline** (surface shaders, `GrabPass`, `OnRenderImage`).
- **Start here:** open `Assets/ShaderNotes/_Common/Scenes/00_Menu.unity` and press Play. All demos are in the
  Build Settings, so you can jump between them: **N / B** next / previous, **M** menu, **H** hide the info panel,
  right mouse to orbit, wheel to zoom.
- **Structure:** `Assets/ShaderNotes/NN_Topic/` contains `Shaders/`, `Scripts/`, `Materials/`, `Textures/`,
  the scene and a `README.md`. `_Common/` holds the shared demo helpers (info panel, menu, orbit camera,
  animators, particle/mesh builders).
- **Textures** are procedurally generated (noises, ramps, LUTs, SDFs, normal maps, cubemap...).

| # | Topic |
|---|-------|
| 01 | [Introduction to image effects](Assets/ShaderNotes/01_Introduction-to-Image-Effects/README.md) |
| 02 | [Simple masks](Assets/ShaderNotes/02_Simple-Masks/README.md) |
| 03 | [Custom masks: disc mask](Assets/ShaderNotes/03_Custom-Masks-Disc/README.md) |
| 04 | [Custom masks: ring mask](Assets/ShaderNotes/04_Custom-Masks-Ring/README.md) |
| 05 | [Random stripes mask](Assets/ShaderNotes/05_Random-Stripes-Mask/README.md) |
| 06 | [Simple displacement](Assets/ShaderNotes/06_Simple-Displacement/README.md) |
| 07 | [Custom wavy displacement](Assets/ShaderNotes/07_Custom-Wavy-Displacement/README.md) |
| 08 | [Waving displacement](Assets/ShaderNotes/08_Waving-Displacement/README.md) |
| 09 | [Chromatic aberration](Assets/ShaderNotes/09_Chromatic-Aberration/README.md) |
| 10 | [Night-time shader](Assets/ShaderNotes/10_Night-Time/README.md) |
| 11 | [Glitch image effect](Assets/ShaderNotes/11_Glitch-Image-Effect/README.md) |
| 12 | [Shockwave effect](Assets/ShaderNotes/12_Shockwave/README.md) |
| 13 | [GrabPass](Assets/ShaderNotes/13_GrabPass/README.md) |
| 14 | [Dissolve shader](Assets/ShaderNotes/14_Dissolve/README.md) |
| 15 | [Stencil shader (Antichamber effect)](Assets/ShaderNotes/15_Stencil-Antichamber/README.md) |
| 16 | [Shader bits: world space & screen space](Assets/ShaderNotes/16_ShaderBits-World-Screen-Space/README.md) |
| 17 | [Shader bits: camera distance, view direction & normals](Assets/ShaderNotes/17_ShaderBits-Distance-ViewDir-Normals/README.md) |
| 18 | [Firewatch multi-coloured fog](Assets/ShaderNotes/18_Firewatch-Fog/README.md) |
| 19 | [ABZÛ portal cards](Assets/ShaderNotes/19_Abzu-Portal-Cards/README.md) |
| 20 | [BLUK visuals (2D fog & parallax)](Assets/ShaderNotes/20_BLUK-Visuals/README.md) |
| 21 | [Directional colouring](Assets/ShaderNotes/21_Directional-Coloring/README.md) |
| 22 | [Snow shader](Assets/ShaderNotes/22_Snow/README.md) |
| 23 | [Shader bits: camera depth textures](Assets/ShaderNotes/23_ShaderBits-Depth-Textures/README.md) |
| 24 | [Edge detection image effect](Assets/ShaderNotes/24_Edge-Detection/README.md) |
| 25 | [Gradient mapper](Assets/ShaderNotes/25_Gradient-Mapper/README.md) |
| 26 | [Directional dissolve](Assets/ShaderNotes/26_Directional-Dissolve/README.md) |
| 27 | [Spherical mask dissolve](Assets/ShaderNotes/27_Spherical-Mask-Dissolve/README.md) |
| 28 | [Unlit waterfall](Assets/ShaderNotes/28_Unlit-Waterfall/README.md) |
| 29 | [Vertical fog (intersection)](Assets/ShaderNotes/29_Vertical-Fog/README.md) |
| 30 | [Teleportation dissolve](Assets/ShaderNotes/30_Teleportation-Dissolve/README.md) |
| 31 | [Radial blur](Assets/ShaderNotes/31_Radial-Blur/README.md) |
| 32 | [Spherical mask post-processing effect](Assets/ShaderNotes/32_Spherical-Mask-PostProcess/README.md) |
| 33 | [Butterflies & fish (vertex animation)](Assets/ShaderNotes/33_Butterflies-and-Fish/README.md) |
| 34 | [Surface shader: custom lighting override](Assets/ShaderNotes/34_Surface-Shader-Lighting/README.md) |
| 35 | [LUT colour grading](Assets/ShaderNotes/35_LUT-Color-Grading/README.md) |
| 36 | [SDF icons](Assets/ShaderNotes/36_SDF-Icons/README.md) |
| 37 | [Parallax effect (part 1)](Assets/ShaderNotes/37_Parallax-Part1/README.md) |
| 38 | [Parallax effect (part 2): layered parallax](Assets/ShaderNotes/38_Parallax-Part2-Layered/README.md) |
| 39 | [Interior mapping](Assets/ShaderNotes/39_Interior-Mapping/README.md) |
| 40 | [VFX master shader (part 1): apprentice](Assets/ShaderNotes/40_VFX-Master-Shader-Part1/README.md) |
| 41 | [VFX master shader (part 2)](Assets/ShaderNotes/41_VFX-Master-Shader-Part2/README.md) |
| 42 | [VFX master shader (part 3): transparent](Assets/ShaderNotes/42_VFX-Master-Shader-Part3/README.md) |
| 43 | [GrabPass distortion](Assets/ShaderNotes/43_GrabPass-Distortion/README.md) |
| 44 | [Simple subsurface scattering](Assets/ShaderNotes/44_Subsurface-Scattering/README.md) |
| 45 | [Water shader](Assets/ShaderNotes/45_Water-Shader/README.md) |
| 46 | [Geometry shaders](Assets/ShaderNotes/46_Geometry-Shaders/README.md) |
| 47 | [Grass shader (part 1)](Assets/ShaderNotes/47_Grass-Shader-Part1/README.md) |
| 48 | [Grass shader (part 2)](Assets/ShaderNotes/48_Grass-Shader-Part2/README.md) |
| 49 | [Cel shading](Assets/ShaderNotes/49_Cel-Shading/README.md) |
| 50 | [Cliff terrain shader](Assets/ShaderNotes/50_Cliff-Terrain/README.md) |
| 51 | [Stylized water shader](Assets/ShaderNotes/51_Stylized-Water/README.md) |
| 52 | [Sky shader](Assets/ShaderNotes/52_Sky-Shader/README.md) |

## Licence

- Third-party licence notice for part of the shader/script code: `Assets/ShaderNotes/LICENSE_ThirdParty.txt`.
- Everything else: this repository's licence (`LICENSE`).
