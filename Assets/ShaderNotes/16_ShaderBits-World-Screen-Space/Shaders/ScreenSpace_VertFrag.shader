// Demo shader built around the "Screen space" vertex/fragment snippet (see Snippets/shader-bits-vertex-fragment.txt).
Shader "ShaderBits/ScreenSpace_VertFrag"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ScreenTiling ("Screen tiling", Float) = 6
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
                float4 scrPos : TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.scrPos = ComputeScreenPos(o.vertex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            // ---------------

            float _ScreenTiling;

            fixed4 frag (v2f i) : SV_Target
            {
                float2 screenUV = i.scrPos.xy / i.scrPos.w;
                screenUV.x *= _ScreenParams.x / _ScreenParams.y;
                fixed4 col = tex2D(_MainTex, screenUV * _ScreenTiling);
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
