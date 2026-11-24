# 19 · ABZÛ portal cards

- **Demo scene:** `19_Abzu-Portal-Cards.unity`

## Notes

Transparent 'light cards' like the ones in ABZÛ: their alpha depends on the distance to the camera, so they fade away as you get close instead of popping through the camera. A sine falloff on U and V softens the quad edges. Zoom towards a card to see it fade.

## Files

- **Shaders/**: `PortalCard.shader`
- **Materials/**: `M_PortalCard.mat`, `M_Seabed.mat`
- **Textures/**: `T_LightShaft.png`

## Implementation notes

-
