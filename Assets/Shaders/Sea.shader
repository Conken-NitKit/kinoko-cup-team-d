Shader "Unlit/Sea"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;

                float3 worldNormal : TEXCOORD1;
				float4 projPos : TEXCOORD2;
				float3 worldPos : TEXCOORD3;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                
				o.projPos = ComputeScreenPos(o.vertex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.worldNormal = UnityObjectToWorldNormal(v.normal); 
				COMPUTE_EYEDEPTH(o.projPos.z);
				return o;
            }

			UNITY_DECLARE_DEPTH_TEXTURE(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)));	
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                const fixed4 phases = fixed4(0.65, 1.28, 0.99, 0.);
                const fixed4 amplitudes = fixed4(1.74, 0.19, 0.37, 0.);
                const fixed4 frequencies = fixed4(0.00, 0.78, 0.43, 0.);
                const fixed4 offsets = fixed4(0.00, 0.00, 0.13, 0.);
                
                fixed4 cos_grad = cosine_gradient(uv.x, phases, amplitudes, frequencies, offsets);
                
                
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }

            fixed4 cosine_gradient(float x,  fixed4 phase, fixed4 amp, fixed4 freq, fixed4 offset){ // https://sp4ghet.github.io/grad/
            const float TAU = 2. * 3.14159265;
            phase *= TAU;
            x *= TAU;

                return fixed4(
                    offset.r + amp.r * 0.5 * cos(x * freq.r + phase.r) + 0.5,
                    offset.g + amp.g * 0.5 * cos(x * freq.g + phase.g) + 0.5,
                    offset.b + amp.b * 0.5 * cos(x * freq.b + phase.b) + 0.5,
                    offset.a + amp.a * 0.5 * cos(x * freq.a + phase.a) + 0.5
                );
            }

            fixed3 toRGB(fixed4 grad){
            return grad.rgb;
            }
                    
            fixed2 uv = gl_FragCoord.xy / resolution;
            fixed4 cos_grad = cosine_gradient(uv.x, phases, amplitudes, frequencies, offsets);
            cos_grad = clamp(cos_grad, 0., 1.);

            fixed4 color = fixed4(toRGB(cos_grad), 1.0);

            gl_FragColor = color;
            }
            ENDCG
        }
    }
}
