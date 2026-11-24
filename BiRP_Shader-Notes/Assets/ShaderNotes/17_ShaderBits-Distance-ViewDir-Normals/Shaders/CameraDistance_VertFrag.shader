// Demo shader built around the "Camera distance" vertex/fragment snippet (see Snippets/shader_bits_vertex_fragment.txt).
Shader "ShaderBits/CameraDistance_VertFrag"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NearColor ("Near color", Color) = (1, 0.9, 0.2, 1)
        _FarColor ("Far color", Color) = (0.6, 0.1, 0.6, 1)
        _MaxDistance ("Max distance", Float) = 25
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

            struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; };
            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 worldPos : TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _NearColor;
            fixed4 _FarColor;
            float _MaxDistance;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            // --- snippet ---
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float camDist = distance(i.worldPos, _WorldSpaceCameraPos);
            // ---------------
                col *= lerp(_NearColor, _FarColor, saturate(camDist / _MaxDistance));
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
