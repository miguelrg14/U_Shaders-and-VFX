# 12 · Shockwave effect

- **Demo scene:** `12_Shockwave.unity`

## Notes

The ring mask from 04 used as a displacement mask. TriggerShockwave.cs moves the centre to the click position and animates _Radius with a coroutine.

Note: the script writes into the material asset, so its values change while playing (by design).

## Controls

Left click: trigger a shockwave at the mouse position

## Files

- **Shaders/**: `ShockWave.shader`
- **Scripts/**: `TriggerShockwave.cs`
- **Materials/**: `M_ShockWave.mat`

## Implementation notes

-
