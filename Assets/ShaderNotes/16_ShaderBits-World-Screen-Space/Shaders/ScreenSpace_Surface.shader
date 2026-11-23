// Demo shader built around the "Screen space" surface-shader snippet (see Snippets/shader-bits-surface.txt).
// Note: in a surface shader screenPos is a float4 and must be divided by w (perspective divide).
Shader "ShaderBits/ScreenSpace_Surface"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _ScreenTiling ("Screen tiling", Float) = 6
        _Glossiness ("Smoothness", Range(0,1)) = 0.3
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        sampler2D _MainTex;
        fixed4 _Color;
        float _ScreenTiling;
        half _Glossiness;

        // --- snippet (screenPos declared as float4) ---
        struct Input {
            float2 uv_MainTex;
            float4 screenPos;
        };
        // ----------------------------------------------

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
            screenUV.x *= _ScreenParams.x / _ScreenParams.y;   // keep the texture square on screen
            fixed4 c = tex2D(_MainTex, screenUV * _ScreenTiling) * _Color;
            o.Albedo = c.rgb;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
