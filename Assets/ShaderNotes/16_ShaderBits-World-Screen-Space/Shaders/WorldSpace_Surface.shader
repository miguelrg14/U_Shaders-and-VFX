// Demo shader built around the "World space" surface-shader snippet (see Snippets/shader-bits-surface.txt).
// The albedo is projected from the world XZ position, so it stays fixed in the world while the object moves.
Shader "ShaderBits/WorldSpace_Surface"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _WorldScale ("World texture scale", Float) = 0.5
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
        float _WorldScale;
        half _Glossiness;

        // --- snippet ---
        struct Input {
            float2 uv_MainTex;
            float3 worldPos;
        };
        // ---------------

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.worldPos.xz * _WorldScale) * _Color;
            o.Albedo = c.rgb;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
