// Image effect built around the "Depth and normals" snippet (see Snippets/shader-bits-camera-depth-textures.txt).
// Use it with CustomImageEffect on a camera whose depthTextureMode includes the needed texture (DemoCameraDepth).
Shader "Hidden/ShaderBits/DepthNormals"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        [ToggleUI] _ShowDepth ("Show depth instead of normals", Float) = 0
    }
    SubShader
    {
        Cull Off ZWrite Off ZTest Always
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 scrPos : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.scrPos = ComputeScreenPos(o.vertex);
                return o;
            }

            sampler2D _MainTex;
            float _ShowDepth;

            // --- snippet ---
            sampler2D _CameraDepthNormalsTexture;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                half3 normal;
                float depth;
                DecodeDepthNormal(tex2D(_CameraDepthNormalsTexture, i.uv), depth, normal);
            // ---------------
                // View-space normals as colour; _ShowDepth > 0.5 shows the encoded 0-1 depth instead.
                fixed4 normalsCol = fixed4(normal * 0.5 + 0.5, 1);
                fixed4 depthCol = fixed4(saturate(depth * 8).xxx, 1);
                return lerp(normalsCol, depthCol, step(0.5, _ShowDepth));
            }
            ENDCG
        }
    }
}
