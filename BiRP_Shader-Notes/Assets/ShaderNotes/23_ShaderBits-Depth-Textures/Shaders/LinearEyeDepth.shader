// Image effect built around the "Linear eye depth" snippet (see Snippets/shader-bits-camera-depth-textures.txt).
// Use it with CustomImageEffect on a camera whose depthTextureMode includes the needed texture (DemoCameraDepth).
Shader "Hidden/ShaderBits/LinearEyeDepth"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BandSize ("Band size (units)", Float) = 2
        _MaxDistance ("Max distance", Float) = 40
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
            float _BandSize;
            float _MaxDistance;

            // --- snippet ---
            sampler2D _CameraDepthTexture;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv);
                depth = LinearEyeDepth(depth);
            // ---------------
                // Eye depth is in world units: show it as bands every _BandSize units, fading at _MaxDistance.
                float bands = frac(depth / _BandSize);
                float fade = saturate(depth / _MaxDistance);
                return lerp(col * 0.25 + bands * 0.75, fixed4(0,0,0,1), fade);
            }
            ENDCG
        }
    }
}
