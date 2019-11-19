// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

// THE ADVANTAGE OF A SHADER LIKE THIS OVER THE "STANDARD SHADER" IS THAT IT HAS A LOT LESS PROPERTIES TO CALCULATE,
// MEANING IT'S MORE PERFORMANT, AND IF THE ONLY BEHAVIOUR WE NEED IS TEXTURE AND COLORS IN OUR MATERIALS, A SHADER LIKE THIS IS ENOUGH

Shader "DJ/DiffuseColor" {

// Properties define what variables are accessible through the Inspector
Properties {
    _MainTex ("Base (RGB)", 2D) = "white" {}
	_Color ("Main Color" , Color ) = (1, 1, 1, 1)
}

// The SubShader defines the actual behaviour of the shader
SubShader {
    Tags { "RenderType"="Opaque" }
    LOD 150

CGPROGRAM
#pragma surface surf Lambert noforwardadd

// The Properties need to also be declared here, so they can be used in the Shader
// Make sure you use the same names as above!
sampler2D _MainTex;
fixed4 _Color;

struct Input {
    float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutput o) {

	// for this specific example, since we simply want to have our color influence the object's visual look,
	// we multiply it by the texture (if there's no texture, only the color will have effect)
    fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
    o.Albedo = c.rgb;
    o.Alpha = c.a;
}
ENDCG
}

Fallback "Mobile/VertexLit"
}
