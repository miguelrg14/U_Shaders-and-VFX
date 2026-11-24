// Image effect built around the "Linear 0-1 depth" snippet (see Snippets/shader-bits-camera-depth-textures.txt).
// Use it with CustomImageEffect on a camera whose depthTextureMode includes the needed texture (DemoCameraDepth).
Shader "Hidden/ShaderBits/Linear01Depth"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Contrast ("Contrast (multiplier)", Float) = 8
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
            float _Contrast;

            // --- snippet ---
            sampler2D _CameraDepthTexture;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float depth = (tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.scrPos)));
                depth = Linear01Depth(depth);
            // ---------------
                // 0 at the camera, 1 at the far clip plane. _Contrast stretches the near range.
                depth = saturate(depth * _Contrast);
                return fixed4(depth, depth, depth, 1);
            }
            ENDCG
        }
    }
}
