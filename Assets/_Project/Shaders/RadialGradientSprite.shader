Shader "Custom/RadialGradientSprite"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {} 
        _FillColor ("Fill Color", Color) = (0.2, 0.6, 0.8, 1)
        _BorderColor ("Border Color", Color) = (1, 1, 1, 1)
        _BorderWidth ("Border Width", Range(0, 0.5)) = 0.05
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque" "Queue"="Geometry"
        }
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
            };

            sampler2D _MainTex; 
            fixed4 _FillColor;
            fixed4 _BorderColor;
            float _BorderWidth;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 dist = abs(i.uv - 0.5);
                float border = max(dist.x, dist.y);

                if (border > 0.5 - _BorderWidth)
                {
                    return _BorderColor;
                }
                else
                {
                    return _FillColor;
                }
            }
            ENDCG
        }
    }
}