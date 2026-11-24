// Minimal re-implementation of the "CustomTessellation.cginc" include used by GrassGeometryShader.shader.
// Provides the entry points the grass shader expects: hull, domain and _TessellationUniform.
// The control point layout matches the grass shader's v2g struct (float4 vertex : POSITION).
#ifndef CUSTOM_TESSELLATION_INCLUDED
#define CUSTOM_TESSELLATION_INCLUDED

float _TessellationUniform;

struct TessellationControlPoint
{
    float4 vertex : POSITION;
};

struct TessellationFactors
{
    float edge[3] : SV_TessFactor;
    float inside : SV_InsideTessFactor;
};

TessellationFactors patchConstantFunction(InputPatch<TessellationControlPoint, 3> patch)
{
    TessellationFactors f;
    f.edge[0] = _TessellationUniform;
    f.edge[1] = _TessellationUniform;
    f.edge[2] = _TessellationUniform;
    f.inside = _TessellationUniform;
    return f;
}

[UNITY_domain("tri")]
[UNITY_outputcontrolpoints(3)]
[UNITY_outputtopology("triangle_cw")]
[UNITY_partitioning("integer")]
[UNITY_patchconstantfunc("patchConstantFunction")]
TessellationControlPoint hull(InputPatch<TessellationControlPoint, 3> patch, uint id : SV_OutputControlPointID)
{
    return patch[id];
}

[UNITY_domain("tri")]
TessellationControlPoint domain(TessellationFactors factors, OutputPatch<TessellationControlPoint, 3> patch, float3 barycentricCoordinates : SV_DomainLocation)
{
    TessellationControlPoint o;
    o.vertex = patch[0].vertex * barycentricCoordinates.x
             + patch[1].vertex * barycentricCoordinates.y
             + patch[2].vertex * barycentricCoordinates.z;
    return o;
}

#endif
