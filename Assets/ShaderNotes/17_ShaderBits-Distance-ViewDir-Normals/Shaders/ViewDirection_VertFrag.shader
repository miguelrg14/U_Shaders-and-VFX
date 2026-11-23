// Demo shader built around the "View direction" vertex/fragment snippet (see Snippets/shader_bits_vertex_fragment.txt;
// the snippet line `normalize(UnityWorldSpaceViewDir(o.worldPos);` is missing a parenthesis).
Shader "ShaderBits/ViewDirection_VertFrag"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _CenterColor ("Facing color", Color) = (0.05, 0.05, 0.1, 1)
        _EdgeColor ("Grazing color", Color) = (1, 0.4, 0.8, 1)
        _Power ("Fresnel power", Range(0.5, 8)) = 2
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

            struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; float3 normal : NORMAL; };

            // --- snippet (+ world normal) ---
            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 worldPos : TEXCOORD2;
                float3 viewDir : TEXCOORD3;
                float3 normal : TEXCOORD4;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.viewDir = normalize(UnityWorldSpaceViewDir(o.worldPos));
                o.normal = UnityObjectToWorldNormal(v.normal);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            // --------------------------------

            fixed4 _CenterColor;
            fixed4 _EdgeColor;
            float _Power;

            fixed4 frag (v2f i) : SV_Target
            {
                float fresnel = pow(1.0 - saturate(dot(normalize(i.viewDir), normalize(i.normal))), _Power);
                fixed4 col = lerp(_CenterColor, _EdgeColor, fresnel);
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
