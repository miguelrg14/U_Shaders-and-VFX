# U_Shaders-and-VFX

Personal study library of shaders and VFX in Unity. Two Unity projects (Unity 6000.6.8f1):

| Project | Pipeline | Content |
|---------|----------|---------|
| [`BiRP_Shader-Notes/`](BiRP_Shader-Notes) | Built-in | Shaders and image effects, one demo scene per topic |
| [`URP_VFX-Notes/`](URP_VFX-Notes) | URP | Real-time VFX made with VFX Graph, one scene per effect |

Open each folder as a separate project in Unity Hub (*Add > Add project from disk*).

## Shader notes (`BiRP_Shader-Notes`)

Notes and experiments on shaders, image effects and VFX techniques, each one with its own **demo scene**,
materials and a README.

- **Unity:** 6000.6.8f1, **Built-in Render Pipeline** (surface shaders, `GrabPass`, `OnRenderImage`).
- **Play it:** [in the browser](https://miguelrg14.github.io/U_Shaders-and-VFX/) (demos 45-48 need geometry/tessellation
  shaders, so they only work in the desktop build) or download the Windows build from
  [Releases](https://github.com/miguelrg14/U_Shaders-and-VFX/releases).
- **Start here:** open `BiRP_Shader-Notes/Assets/ShaderNotes/_Common/Scenes/00_Menu.unity` and press Play. All demos are in the
  Build Settings, so you can jump between them: **N / B** next / previous, **M** menu, **H** hide the info panel,
  right mouse to orbit, wheel to zoom.
- **Structure:** `BiRP_Shader-Notes/Assets/ShaderNotes/NN_Topic/` contains `Shaders/`, `Scripts/`, `Materials/`, `Textures/`,
  the scene and a `README.md`. `_Common/` holds the shared demo helpers (info panel, menu, orbit camera,
  animators, particle/mesh builders).
- **Textures** are procedurally generated (noises, ramps, LUTs, SDFs, normal maps, cubemap...).

| # | Topic |
|---|-------|
| 01 | [Introduction to image effects](BiRP_Shader-Notes/Assets/ShaderNotes/01_Introduction-to-Image-Effects/README.md) |
| 02 | [Simple masks](BiRP_Shader-Notes/Assets/ShaderNotes/02_Simple-Masks/README.md) |
| 03 | [Custom masks: disc mask](BiRP_Shader-Notes/Assets/ShaderNotes/03_Custom-Masks-Disc/README.md) |
| 04 | [Custom masks: ring mask](BiRP_Shader-Notes/Assets/ShaderNotes/04_Custom-Masks-Ring/README.md) |
| 05 | [Random stripes mask](BiRP_Shader-Notes/Assets/ShaderNotes/05_Random-Stripes-Mask/README.md) |
| 06 | [Simple displacement](BiRP_Shader-Notes/Assets/ShaderNotes/06_Simple-Displacement/README.md) |
| 07 | [Custom wavy displacement](BiRP_Shader-Notes/Assets/ShaderNotes/07_Custom-Wavy-Displacement/README.md) |
| 08 | [Waving displacement](BiRP_Shader-Notes/Assets/ShaderNotes/08_Waving-Displacement/README.md) |
| 09 | [Chromatic aberration](BiRP_Shader-Notes/Assets/ShaderNotes/09_Chromatic-Aberration/README.md) |
| 10 | [Night-time shader](BiRP_Shader-Notes/Assets/ShaderNotes/10_Night-Time/README.md) |
| 11 | [Glitch image effect](BiRP_Shader-Notes/Assets/ShaderNotes/11_Glitch-Image-Effect/README.md) |
| 12 | [Shockwave effect](BiRP_Shader-Notes/Assets/ShaderNotes/12_Shockwave/README.md) |
| 13 | [GrabPass](BiRP_Shader-Notes/Assets/ShaderNotes/13_GrabPass/README.md) |
| 14 | [Dissolve shader](BiRP_Shader-Notes/Assets/ShaderNotes/14_Dissolve/README.md) |
| 15 | [Stencil shader (Antichamber effect)](BiRP_Shader-Notes/Assets/ShaderNotes/15_Stencil-Antichamber/README.md) |
| 16 | [Shader bits: world space & screen space](BiRP_Shader-Notes/Assets/ShaderNotes/16_ShaderBits-World-Screen-Space/README.md) |
| 17 | [Shader bits: camera distance, view direction & normals](BiRP_Shader-Notes/Assets/ShaderNotes/17_ShaderBits-Distance-ViewDir-Normals/README.md) |
| 18 | [Firewatch multi-coloured fog](BiRP_Shader-Notes/Assets/ShaderNotes/18_Firewatch-Fog/README.md) |
| 19 | [ABZÛ portal cards](BiRP_Shader-Notes/Assets/ShaderNotes/19_Abzu-Portal-Cards/README.md) |
| 20 | [BLUK visuals (2D fog & parallax)](BiRP_Shader-Notes/Assets/ShaderNotes/20_BLUK-Visuals/README.md) |
| 21 | [Directional colouring](BiRP_Shader-Notes/Assets/ShaderNotes/21_Directional-Coloring/README.md) |
| 22 | [Snow shader](BiRP_Shader-Notes/Assets/ShaderNotes/22_Snow/README.md) |
| 23 | [Shader bits: camera depth textures](BiRP_Shader-Notes/Assets/ShaderNotes/23_ShaderBits-Depth-Textures/README.md) |
| 24 | [Edge detection image effect](BiRP_Shader-Notes/Assets/ShaderNotes/24_Edge-Detection/README.md) |
| 25 | [Gradient mapper](BiRP_Shader-Notes/Assets/ShaderNotes/25_Gradient-Mapper/README.md) |
| 26 | [Directional dissolve](BiRP_Shader-Notes/Assets/ShaderNotes/26_Directional-Dissolve/README.md) |
| 27 | [Spherical mask dissolve](BiRP_Shader-Notes/Assets/ShaderNotes/27_Spherical-Mask-Dissolve/README.md) |
| 28 | [Unlit waterfall](BiRP_Shader-Notes/Assets/ShaderNotes/28_Unlit-Waterfall/README.md) |
| 29 | [Vertical fog (intersection)](BiRP_Shader-Notes/Assets/ShaderNotes/29_Vertical-Fog/README.md) |
| 30 | [Teleportation dissolve](BiRP_Shader-Notes/Assets/ShaderNotes/30_Teleportation-Dissolve/README.md) |
| 31 | [Radial blur](BiRP_Shader-Notes/Assets/ShaderNotes/31_Radial-Blur/README.md) |
| 32 | [Spherical mask post-processing effect](BiRP_Shader-Notes/Assets/ShaderNotes/32_Spherical-Mask-PostProcess/README.md) |
| 33 | [Butterflies & fish (vertex animation)](BiRP_Shader-Notes/Assets/ShaderNotes/33_Butterflies-and-Fish/README.md) |
| 34 | [Surface shader: custom lighting override](BiRP_Shader-Notes/Assets/ShaderNotes/34_Surface-Shader-Lighting/README.md) |
| 35 | [LUT colour grading](BiRP_Shader-Notes/Assets/ShaderNotes/35_LUT-Color-Grading/README.md) |
| 36 | [SDF icons](BiRP_Shader-Notes/Assets/ShaderNotes/36_SDF-Icons/README.md) |
| 37 | [Parallax effect (part 1)](BiRP_Shader-Notes/Assets/ShaderNotes/37_Parallax-Part1/README.md) |
| 38 | [Parallax effect (part 2): layered parallax](BiRP_Shader-Notes/Assets/ShaderNotes/38_Parallax-Part2-Layered/README.md) |
| 39 | [Interior mapping](BiRP_Shader-Notes/Assets/ShaderNotes/39_Interior-Mapping/README.md) |
| 40 | [VFX master shader (part 1): apprentice](BiRP_Shader-Notes/Assets/ShaderNotes/40_VFX-Master-Shader-Part1/README.md) |
| 41 | [VFX master shader (part 2)](BiRP_Shader-Notes/Assets/ShaderNotes/41_VFX-Master-Shader-Part2/README.md) |
| 42 | [VFX master shader (part 3): transparent](BiRP_Shader-Notes/Assets/ShaderNotes/42_VFX-Master-Shader-Part3/README.md) |
| 43 | [GrabPass distortion](BiRP_Shader-Notes/Assets/ShaderNotes/43_GrabPass-Distortion/README.md) |
| 44 | [Simple subsurface scattering](BiRP_Shader-Notes/Assets/ShaderNotes/44_Subsurface-Scattering/README.md) |
| 45 | [Water shader](BiRP_Shader-Notes/Assets/ShaderNotes/45_Water-Shader/README.md) |
| 46 | [Geometry shaders](BiRP_Shader-Notes/Assets/ShaderNotes/46_Geometry-Shaders/README.md) |
| 47 | [Grass shader (part 1)](BiRP_Shader-Notes/Assets/ShaderNotes/47_Grass-Shader-Part1/README.md) |
| 48 | [Grass shader (part 2)](BiRP_Shader-Notes/Assets/ShaderNotes/48_Grass-Shader-Part2/README.md) |
| 49 | [Cel shading](BiRP_Shader-Notes/Assets/ShaderNotes/49_Cel-Shading/README.md) |
| 50 | [Cliff terrain shader](BiRP_Shader-Notes/Assets/ShaderNotes/50_Cliff-Terrain/README.md) |
| 51 | [Stylized water shader](BiRP_Shader-Notes/Assets/ShaderNotes/51_Stylized-Water/README.md) |
| 52 | [Sky shader](BiRP_Shader-Notes/Assets/ShaderNotes/52_Sky-Shader/README.md) |

## VFX notes (`URP_VFX-Notes`)

Real-time VFX built with **VFX Graph** in URP (bloom + ACES tonemapping), one folder and scene per effect.
See [`URP_VFX-Notes/Assets/VFXNotes/README.md`](URP_VFX-Notes/Assets/VFXNotes/README.md) for the workflow.
VFX Graph needs compute shaders, so these effects ship only in the Windows build
([Releases](https://github.com/miguelrg14/U_Shaders-and-VFX/releases)).

## Licence

- Third-party licence notice for part of the shader/script code: `BiRP_Shader-Notes/Assets/ShaderNotes/LICENSE_ThirdParty.txt`.
- Everything else: this repository's licence (`LICENSE`).
