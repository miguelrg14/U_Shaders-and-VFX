// Demo shader built around the "World space" vertex/fragment snippet (see Snippets/shader-bits-vertex-fragment.txt).
// Draws a world-aligned grid from frac(worldPos): the lines stay still while the object moves through them.
Shader "ShaderBits/WorldSpace_VertFrag"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _GridColor ("Grid color", Color) = (1, 0.6, 0.1, 1)
        _BaseColor ("Base color", Color) = (0.1, 0.1, 0.15, 1)
        _GridScale ("Grid cells per unit", Float) = 2
        _LineWidth ("Line width", Range(0.01, 0.5)) = 0.06
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            // --- snippet ---
            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 worldPos : TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            // ---------------

            fixed4 _GridColor;
            fixed4 _BaseColor;
            float _GridScale;
            float _LineWidth;

            fixed4 frag (v2f i) : SV_Target
            {
                float3 cell = abs(frac(i.worldPos.xyz * _GridScale) - 0.5);
                float lines = step(0.5 - _LineWidth, max(max(cell.x, cell.y), cell.z));
                fixed4 col = lerp(_BaseColor, _GridColor, lines);
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
