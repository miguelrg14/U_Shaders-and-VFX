# 33 · Butterflies & fish (vertex animation)

- **Demo scene:** `33_Butterflies-and-Fish.unity`

## Notes

Cheap vertex animation. Butterflies: a horizontal subdivided quad whose vertices move up and down by a sine masked with 1 - sin(PI * u), so the body stays still and the wings flap. Fish: a subdivided vertical quad whose vertices move along their normal with a travelling sine wave, masked so the tail moves more. (The quads are subdivided by DemoProceduralMesh - a 4-vertex quad cannot bend.)

## Files

- **Shaders/**: `ButterflyShader.shader`, `FishShader.shader`
- **Materials/**: `M_Butterfly.mat`, `M_Fish_A.mat`, `M_Fish_B.mat`
- **Textures/**: `T_Butterfly.png`, `T_Fish.png`

## Implementation notes

-
