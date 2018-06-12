Shader "MyInwardShader" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Cull Off

		CGPROGRAM
		// use diffuse lighting model
		#pragma surface surf Lambert 


		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		void vert(inout appdata_full v) {
			v.normal.xyz = v.normal * -1;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
