# 15 · Stencil shader (Antichamber effect)

- **Demo scene:** `15_Stencil-Antichamber.unity`

## Notes

Antichamber-style 'impossible box'. Each face is a quad with StencilMask (ColorMask 0, ZWrite Off, Queue Geometry-100) that writes its reference number into the stencil buffer. The objects inside use StencilObject (Comp Equal), so each one is only visible through the face with the same reference.

## Files

- **Shaders/**: `StencilMask.shader`, `StencilObject.shader`
- **Materials/**: `M_StencilMask_Ref1.mat`, `M_StencilMask_Ref2.mat`, `M_StencilMask_Ref3.mat`, `M_StencilMask_Ref4.mat`, `M_StencilObject_Ref1.mat`, `M_StencilObject_Ref2.mat`, `M_StencilObject_Ref3.mat`, `M_StencilObject_Ref4.mat`

## Implementation notes

- `StencilMask.shader`: Old instancing macros `UNITY_INSTANCING_CBUFFER_START/END` renamed to `UNITY_INSTANCING_BUFFER_START/END(Props)`.
- `StencilObject.shader`: Old instancing macros `UNITY_INSTANCING_CBUFFER_START/END` renamed to `UNITY_INSTANCING_BUFFER_START/END(Props)`.
