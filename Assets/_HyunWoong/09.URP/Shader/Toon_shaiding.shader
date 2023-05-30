Shader "Hyun/Toon_shading"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        [HDR]
        _AmbientColor("Ambient Color", Color) = (0.4,0.4,0.4,1)
        [HDR]
        _SpecularColor("Specular Color", Color) = (0.9,0.9,0.9,1)
        _Glossiness("Glossiness", Float) = 32
        [HDR]
        _RimColor("Rim Color", Color) = (1,1,1,1)
        _RimAmount("Rim Amount", Range(0,1)) = 0.716
        _RimThreshold("Rim Threshold", Range(0,1)) = 0.1
        _OutlineWidth("OutlineWidth", Float) = 0.01
    }
    SubShader
    {
		Tags{
			"RenderPipeline" = "UniversalPipeline"
			"LightMode" = "ForwardBase"
	        "PassFlags" = "OnlyDirectional"
		}
        Pass{

		cull back
        HLSLPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #pragma multi_compile_fwdbase

        #include "UnityCG.cginc"
		#include "Lighting.cginc"
		#include "AutoLight.cginc"

        sampler2D _MainTex;
        struct appdata
			{
				float4 vertex : POSITION;				
				float4 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float3 worldNormal : NORMAL;
				float2 uv : TEXCOORD0;
				float3 viewDir : TEXCOORD1;	
				SHADOW_COORDS(2)
			};

            float Dot(float3 normal, float3 direction){
                return normal.x * direction.x +  normal.y * direction.y +normal.z * direction.z;
            }

			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);		
				o.viewDir = WorldSpaceViewDir(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				TRANSFER_SHADOW(o)
				return o;
			}
			
			float4 _Color;

			float4 _AmbientColor;

			float4 _SpecularColor;
			float _Glossiness;		

			float4 _RimColor;
			float _RimAmount;
			float _RimThreshold;	

			float4 frag (v2f i) : SV_Target
			{
				float3 normal = normalize(i.worldNormal);
				float3 viewDir = normalize(i.viewDir);

				float NdotL = Dot(_WorldSpaceLightPos0, normal);

				float shadow = SHADOW_ATTENUATION(i);
				float lightIntensity = smoothstep(0, 0.01, NdotL * shadow);	
				float4 light = lightIntensity * _LightColor0;

				float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);
				float NdotH = Dot(normal, halfVector);
				float specularIntensity = pow(NdotH * lightIntensity, _Glossiness * _Glossiness);
				float specularIntensitySmooth = smoothstep(0.005, 0.01, specularIntensity);
				float4 specular = specularIntensitySmooth * _SpecularColor;				

				float rimDot = 1 - Dot(viewDir, normal);
				float rimIntensity = rimDot * pow(NdotL, _RimThreshold);
				rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimIntensity);
				float4 rim = rimIntensity * _RimColor;

				float4 sample = tex2D(_MainTex, i.uv);

				return (light + _AmbientColor + specular + rim) * _Color * sample;
			}
        ENDHLSL

		
    	}
		cull front
        CGPROGRAM
        #pragma surface surf Lambert vertex:vert
        float _OutlineWidth;

        struct Input
        {
            float _Blank;
        };

        void vert(inout appdata_full v){
            v.vertex.xyz += v.normal.xyz*_OutlineWidth;
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = 0;
        }
        ENDCG

    //UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
	}
}
