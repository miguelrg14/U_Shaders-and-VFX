// Demo shader built around the "View direction" surface snippet (see Snippets/shader_bits_surface.txt).
// When o.Normal is not written, IN.viewDir is in world space; here it is combined with the world normal for a rim.
Shader "ShaderBits/ViewDirection_Surface"
{
    Properties
    {
        _Color ("Color", Color) = (0.15,0.2,0.3,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        [HDR]_RimColor ("Rim color", Color) = (0.3, 0.9, 1.5, 1)
        _RimPower ("Rim power", Range(0.5, 8)) = 3
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        sampler2D _MainTex;
        fixed4 _Color;
        fixed4 _RimColor;
        float _RimPower;

        // --- snippet (+ worldNormal) ---
        struct Input {
            float2 uv_MainTex;
            float3 viewDir;
            float3 worldNormal;
        };
        // -------------------------------

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            float rim = pow(1.0 - saturate(dot(normalize(IN.viewDir), normalize(IN.worldNormal))), _RimPower);
            o.Albedo = c.rgb;
            o.Emission = _RimColor.rgb * rim;
            o.Smoothness = 0.4;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
