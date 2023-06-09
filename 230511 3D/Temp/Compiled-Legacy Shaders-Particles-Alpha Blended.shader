// Compiled shader for Windows, Mac, Linux

//////////////////////////////////////////////////////////////////////////
// 
// NOTE: This is *not* a valid shader file, the contents are provided just
// for information and for debugging purposes only.
// 
//////////////////////////////////////////////////////////////////////////
// Skipping shader variants that would not be included into build of current scene.

Shader "Legacy Shaders/Particles/Alpha Blended" {
Properties {
 _TintColor ("Tint Color", Color) = (0.500000,0.500000,0.500000,0.500000)
 _MainTex ("Particle Texture", 2D) = "white" { }
 _InvFade ("Soft Particles Factor", Range(0.010000,3.000000)) = 1.000000
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" "PreviewType"="Plane" }


 // Stats for Vertex shader:
 //        d3d11: 14 avg math (10..19)
 // Stats for Fragment shader:
 //        d3d11: 5 avg math (2..8), 1 avg texture (1..2)
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" "PreviewType"="Plane" }
  ZWrite Off
  Cull Off
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask RGB
  //////////////////////////////////
  //                              //
  //      Compiled programs       //
  //                              //
  //////////////////////////////////
//////////////////////////////////////////////////////
Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Stats: 10 math, 2 temp registers
Uses vertex data channel "Vertex"
Uses vertex data channel "Color"
Uses vertex data channel "TexCoord0"

Constant Buffer "$Globals" (80 bytes) on slot 0 {
  Vector4 _TintColor at 32
  Vector4 _MainTex_ST at 48
}
Constant Buffer "UnityPerDraw" (176 bytes) on slot 1 {
  Matrix4x4 unity_ObjectToWorld at 0
}
Constant Buffer "UnityPerFrame" (368 bytes) on slot 2 {
  Matrix4x4 unity_MatrixVP at 272
}

Shader Disassembly:
//
// Generated by Microsoft (R) D3D Shader Disassembler
//
//
// Input signature:
//
// Name                 Index   Mask Register SysValue  Format   Used
// -------------------- ----- ------ -------- -------- ------- ------
// POSITION                 0   xyzw        0     NONE   float   xyz 
// COLOR                    0   xyzw        1     NONE   float   xyzw
// TEXCOORD                 0   xy          2     NONE   float   xy  
//
//
// Output signature:
//
// Name                 Index   Mask Register SysValue  Format   Used
// -------------------- ----- ------ -------- -------- ------- ------
// SV_POSITION              0   xyzw        0      POS   float   xyzw
// COLOR                    0   xyzw        1     NONE   float   xyzw
// TEXCOORD                 0   xy          2     NONE   float   xy  
//
      vs_4_0
      dcl_constantbuffer CB0[4], immediateIndexed
      dcl_constantbuffer CB1[4], immediateIndexed
      dcl_constantbuffer CB2[21], immediateIndexed
      dcl_input v0.xyz
      dcl_input v1.xyzw
      dcl_input v2.xy
      dcl_output_siv o0.xyzw, position
      dcl_output o1.xyzw
      dcl_output o2.xy
      dcl_temps 2
   0: mul r0.xyzw, v0.yyyy, cb1[1].xyzw
   1: mad r0.xyzw, cb1[0].xyzw, v0.xxxx, r0.xyzw
   2: mad r0.xyzw, cb1[2].xyzw, v0.zzzz, r0.xyzw
   3: add r0.xyzw, r0.xyzw, cb1[3].xyzw
   4: mul r1.xyzw, r0.yyyy, cb2[18].xyzw
   5: mad r1.xyzw, cb2[17].xyzw, r0.xxxx, r1.xyzw
   6: mad r1.xyzw, cb2[19].xyzw, r0.zzzz, r1.xyzw
   7: mad o0.xyzw, cb2[20].xyzw, r0.wwww, r1.xyzw
   8: mul o1.xyzw, v1.xyzw, cb0[2].xyzw
   9: mad o2.xy, v2.xyxx, cb0[3].xyxx, cb0[3].zwzz
  10: ret 
// Approximately 0 instruction slots used


-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Stats: 2 math, 2 temp registers, 1 textures
Set 2D Texture "_MainTex" to slot 0

Shader Disassembly:
//
// Generated by Microsoft (R) D3D Shader Disassembler
//
//
// Input signature:
//
// Name                 Index   Mask Register SysValue  Format   Used
// -------------------- ----- ------ -------- -------- ------- ------
// SV_POSITION              0   xyzw        0      POS   float       
// COLOR                    0   xyzw        1     NONE   float   xyzw
// TEXCOORD                 0   xy          2     NONE   float   xy  
//
//
// Output signature:
//
// Name                 Index   Mask Register SysValue  Format   Used
// -------------------- ----- ------ -------- -------- ------- ------
// SV_Target                0   xyzw        0   TARGET   float   xyzw
//
      ps_4_0
      dcl_sampler s0, mode_default
      dcl_resource_texture2d (float,float,float,float) t0
      dcl_input_ps linear v1.xyzw
      dcl_input_ps linear v2.xy
      dcl_output o0.xyzw
      dcl_temps 2
   0: add r0.xyzw, v1.xyzw, v1.xyzw
   1: sample r1.xyzw, v2.xyxx, t0.xyzw, s0
   2: mul r0.xyzw, r0.xyzw, r1.xyzw
   3: mov_sat o0.w, r0.w
   4: mov o0.xyz, r0.xyzx
   5: ret 
// Approximately 0 instruction slots used


//////////////////////////////////////////////////////
Keywords: SOFTPARTICLES_ON
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Stats: 19 math, 2 temp registers
Uses vertex data channel "Vertex"
Uses vertex data channel "Color"
Uses vertex data channel "TexCoord0"

Constant Buffer "$Globals" (80 bytes) on slot 0 {
  Vector4 _TintColor at 32
  Vector4 _MainTex_ST at 48
}
Constant Buffer "UnityPerCamera" (144 bytes) on slot 1 {
  Vector4 _ProjectionParams at 80
}
Constant Buffer "UnityPerDraw" (176 bytes) on slot 2 {
  Matrix4x4 unity_ObjectToWorld at 0
}
Constant Buffer "UnityPerFrame" (368 bytes) on slot 3 {
  Matrix4x4 unity_MatrixV at 144
  Matrix4x4 unity_MatrixVP at 272
}

Shader Disassembly:
//
// Generated by Microsoft (R) D3D Shader Disassembler
//
//
// Input signature:
//
// Name                 Index   Mask Register SysValue  Format   Used
// -------------------- ----- ------ -------- -------- ------- ------
// POSITION                 0   xyzw        0     NONE   float   xyz 
// COLOR                    0   xyzw        1     NONE   float   xyzw
// TEXCOORD                 0   xy          2     NONE   float   xy  
//
//
// Output signature:
//
// Name                 Index   Mask Register SysValue  Format   Used
// -------------------- ----- ------ -------- -------- ------- ------
// SV_POSITION              0   xyzw        0      POS   float   xyzw
// COLOR                    0   xyzw        1     NONE   float   xyzw
// TEXCOORD                 0   xy          2     NONE   float   xy  
// TEXCOORD                 2   xyzw        3     NONE   float   xyzw
//
      vs_4_0
      dcl_constantbuffer CB0[4], immediateIndexed
      dcl_constantbuffer CB1[6], immediateIndexed
      dcl_constantbuffer CB2[4], immediateIndexed
      dcl_constantbuffer CB3[21], immediateIndexed
      dcl_input v0.xyz
      dcl_input v1.xyzw
      dcl_input v2.xy
      dcl_output_siv o0.xyzw, position
      dcl_output o1.xyzw
      dcl_output o2.xy
      dcl_output o3.xyzw
      dcl_temps 2
   0: mul r0.xyzw, v0.yyyy, cb2[1].xyzw
   1: mad r0.xyzw, cb2[0].xyzw, v0.xxxx, r0.xyzw
   2: mad r0.xyzw, cb2[2].xyzw, v0.zzzz, r0.xyzw
   3: add r0.xyzw, r0.xyzw, cb2[3].xyzw
   4: mul r1.xyzw, r0.yyyy, cb3[18].xyzw
   5: mad r1.xyzw, cb3[17].xyzw, r0.xxxx, r1.xyzw
   6: mad r1.xyzw, cb3[19].xyzw, r0.zzzz, r1.xyzw
   7: mad r1.xyzw, cb3[20].xyzw, r0.wwww, r1.xyzw
   8: mov o0.xyzw, r1.xyzw
   9: mul o1.xyzw, v1.xyzw, cb0[2].xyzw
  10: mad o2.xy, v2.xyxx, cb0[3].xyxx, cb0[3].zwzz
  11: mul r0.y, r0.y, cb3[10].z
  12: mad r0.x, cb3[9].z, r0.x, r0.y
  13: mad r0.x, cb3[11].z, r0.z, r0.x
  14: mad r0.x, cb3[12].z, r0.w, r0.x
  15: mov o3.z, -r0.x
  16: mul r0.x, r1.y, cb1[5].x
  17: mul r0.w, r0.x, l(0.500000)
  18: mul r0.xz, r1.xxwx, l(0.500000, 0.000000, 0.500000, 0.000000)
  19: mov o3.w, r1.w
  20: add o3.xy, r0.zzzz, r0.xwxx
  21: ret 
// Approximately 0 instruction slots used


-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Stats: 8 math, 2 temp registers, 2 textures
Set 2D Texture "_CameraDepthTexture" to slot 0 sampler slot 1
Set 2D Texture "_MainTex" to slot 1 sampler slot 0

Constant Buffer "$Globals" (80 bytes) on slot 0 {
  Float _InvFade at 64
}
Constant Buffer "UnityPerCamera" (144 bytes) on slot 1 {
  Vector4 _ZBufferParams at 112
}

Shader Disassembly:
//
// Generated by Microsoft (R) D3D Shader Disassembler
//
//
// Input signature:
//
// Name                 Index   Mask Register SysValue  Format   Used
// -------------------- ----- ------ -------- -------- ------- ------
// SV_POSITION              0   xyzw        0      POS   float       
// COLOR                    0   xyzw        1     NONE   float   xyzw
// TEXCOORD                 0   xy          2     NONE   float   xy  
// TEXCOORD                 2   xyzw        3     NONE   float   xyzw
//
//
// Output signature:
//
// Name                 Index   Mask Register SysValue  Format   Used
// -------------------- ----- ------ -------- -------- ------- ------
// SV_Target                0   xyzw        0   TARGET   float   xyzw
//
      ps_4_0
      dcl_constantbuffer CB0[5], immediateIndexed
      dcl_constantbuffer CB1[8], immediateIndexed
      dcl_sampler s0, mode_default
      dcl_sampler s1, mode_default
      dcl_resource_texture2d (float,float,float,float) t0
      dcl_resource_texture2d (float,float,float,float) t1
      dcl_input_ps linear v1.xyzw
      dcl_input_ps linear v2.xy
      dcl_input_ps linear v3.xyzw
      dcl_output o0.xyzw
      dcl_temps 2
   0: div r0.xy, v3.xyxx, v3.wwww
   1: sample r0.xyzw, r0.xyxx, t0.xyzw, s1
   2: mad r0.x, cb1[7].z, r0.x, cb1[7].w
   3: div r0.x, l(1.000000, 1.000000, 1.000000, 1.000000), r0.x
   4: add r0.x, r0.x, -v3.z
   5: mul_sat r0.x, r0.x, cb0[4].x
   6: mul r0.w, r0.x, v1.w
   7: mov r0.xyz, v1.xyzx
   8: add r0.xyzw, r0.xyzw, r0.xyzw
   9: sample r1.xyzw, v2.xyxx, t1.xyzw, s0
  10: mul r0.xyzw, r0.xyzw, r1.xyzw
  11: mov_sat o0.w, r0.w
  12: mov o0.xyz, r0.xyzx
  13: ret 
// Approximately 0 instruction slots used


 }
}
}