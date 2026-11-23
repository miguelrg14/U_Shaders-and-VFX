// Demo shader built around the "Camera distance" surface snippet (see Snippets/shader_bits_surface.txt).
Shader "ShaderBits/CameraDistance_Surface"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _NearColor ("Near color", Color) = (1, 0.45, 0.1, 1)
        _FarColor ("Far color", Color) = (0.15, 0.3, 1, 1)
        _MaxDistance ("Max distance", Float) = 25
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        sampler2D _MainTex;
        fixed4 _Color;
        half _Glossiness;
        half _Metallic;
        fixed4 _NearColor;
        fixed4 _FarColor;
        float _MaxDistance;

        // --- snippet ---
        struct Input {
            float2 uv_MainTex;
            float3 worldPos;
        };

        void surf (Input IN, inout SurfaceOutputStandard o) {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            float camDist = distance(IN.worldPos, _WorldSpaceCameraPos);
        // ---------------
            o.Albedo = c.rgb * lerp(_NearColor.rgb, _FarColor.rgb, saturate(camDist / _MaxDistance));
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
