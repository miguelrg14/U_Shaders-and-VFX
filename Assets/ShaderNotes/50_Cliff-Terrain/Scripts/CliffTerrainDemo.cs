using System;
using UnityEngine;

/// <summary>
/// Demo helper.
/// CliffTerrainShader is written for Unity's Terrain, which automatically sets _Control, _Splat0-3,
/// _Normal0-3, _NormalScale0-3, _Smoothness0-3 and _Metallic0-3. This component builds a procedural
/// terraced height-field mesh plus a splat (control) map and feeds the same properties through a
/// MaterialPropertyBlock, so the shader can be studied without a TerrainData asset.
/// </summary>
[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CliffTerrainDemo : MonoBehaviour
{
    [Serializable]
    public class Layer
    {
        public Texture2D albedo;
        public Texture2D normal;
        public float tiling = 10f;
        public float normalScale = 1f;
        [Range(0f, 1f)] public float smoothness = 0.1f;
        [Range(0f, 1f)] public float metallic = 0f;
    }

    [Tooltip("0 = low ground, 1 = mid ground, 2 = high ground, 3 = peaks")]
    public Layer[] layers = new Layer[4];

    [Header("Height field")]
    public int resolution = 160;
    public float size = 80f;
    public float height = 24f;
    public int seed = 7;
    public float noiseScale = 0.035f;
    [Tooltip("Number of plateaus; the steep steps between them become cliffs.")]
    public float terraces = 5f;
    [Range(0f, 0.99f)] public float terraceSharpness = 0.8f;
    [Range(0f, 1f)] public float terraceBlend = 0.85f;

    private Mesh mesh;
    private Texture2D control;
    private MaterialPropertyBlock block;

    private void OnEnable() { Build(); }

    private void OnValidate()
    {
        // Rebuilding the mesh from OnValidate is not allowed; just refresh the material properties.
        if (isActiveAndEnabled && mesh != null) ApplyProperties();
    }

    private void OnDisable()
    {
        if (mesh != null) DestroyImmediate(mesh);
        if (control != null) DestroyImmediate(control);
    }

    private float Height01(float x, float z)
    {
        float ox = seed * 37.1f, oz = seed * 17.3f;
        float h = 0f, amp = 1f, freq = noiseScale, norm = 0f;
        for (int o = 0; o < 5; o++)
        {
            h += Mathf.PerlinNoise(x * freq + ox, z * freq + oz) * amp;
            norm += amp;
            amp *= 0.5f;
            freq *= 2f;
        }
        h /= norm;
        // Island-like fall-off towards the borders.
        float dx = x / size - 0.5f, dz = z / size - 0.5f;
        h *= Mathf.Clamp01(1.25f - Mathf.Sqrt(dx * dx + dz * dz) * 2f);
        h = Mathf.Clamp01((h - 0.15f) * 1.6f);
        // Terraces: flat plateaus with steep steps in between.
        float t = h * terraces;
        float step = Mathf.Floor(t);
        float f = Mathf.Clamp01((t - step - terraceSharpness) / (1f - terraceSharpness));
        float terraced = (step + f) / terraces;
        return Mathf.Lerp(h, terraced, terraceBlend);
    }

    public void Build()
    {
        int res = Mathf.Clamp(resolution, 8, 250);
        if (mesh == null) mesh = new Mesh { name = "CliffTerrainDemo", hideFlags = HideFlags.HideAndDontSave };
        mesh.Clear();

        var vertices = new Vector3[res * res];
        var uvs = new Vector2[res * res];
        var heights = new float[res * res];
        for (int z = 0; z < res; z++)
        {
            for (int x = 0; x < res; x++)
            {
                float px = (float)x / (res - 1) * size, pz = (float)z / (res - 1) * size;
                float h = Height01(px, pz);
                heights[z * res + x] = h;
                vertices[z * res + x] = new Vector3(px - size * 0.5f, h * height, pz - size * 0.5f);
                uvs[z * res + x] = new Vector2((float)x / (res - 1), (float)z / (res - 1));
            }
        }
        var tris = new int[(res - 1) * (res - 1) * 6];
        int t = 0;
        for (int z = 0; z < res - 1; z++)
        {
            for (int x = 0; x < res - 1; x++)
            {
                int i = z * res + x;
                tris[t++] = i; tris[t++] = i + res; tris[t++] = i + 1;
                tris[t++] = i + 1; tris[t++] = i + res; tris[t++] = i + res + 1;
            }
        }
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = tris;
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        mesh.RecalculateBounds();
        GetComponent<MeshFilter>().sharedMesh = mesh;

        // Splat map: R = low, G = mid, B = high, A = peaks (weights sum to 1, like Unity's terrain).
        const int cs = 256;
        if (control == null)
        {
            control = new Texture2D(cs, cs, TextureFormat.RGBA32, false, true)
            {
                name = "CliffTerrainDemo_Control",
                hideFlags = HideFlags.HideAndDontSave,
                wrapMode = TextureWrapMode.Clamp
            };
        }
        var pixels = new Color[cs * cs];
        for (int y = 0; y < cs; y++)
        {
            for (int x = 0; x < cs; x++)
            {
                float h = Height01((float)x / (cs - 1) * size, (float)y / (cs - 1) * size);
                float w0 = Mathf.Clamp01(1f - h / 0.12f);
                float w1 = Mathf.Clamp01(1f - Mathf.Abs(h - 0.3f) / 0.22f);
                float w2 = Mathf.Clamp01(1f - Mathf.Abs(h - 0.6f) / 0.2f);
                float w3 = Mathf.Clamp01((h - 0.68f) / 0.15f);
                float sum = Mathf.Max(0.0001f, w0 + w1 + w2 + w3);
                pixels[y * cs + x] = new Color(w0 / sum, w1 / sum, w2 / sum, w3 / sum);
            }
        }
        control.SetPixels(pixels);
        control.Apply();

        ApplyProperties();
    }

    private void ApplyProperties()
    {
        var r = GetComponent<MeshRenderer>();
        if (block == null) block = new MaterialPropertyBlock();
        r.GetPropertyBlock(block);
        block.SetTexture("_Control", control);
        // _Control is not declared in the shader's Properties block, so its _ST must be set by hand
        // (otherwise the surface shader's uv_Control would be multiplied by zero).
        block.SetVector("_Control_ST", new Vector4(1f, 1f, 0f, 0f));
        for (int i = 0; i < 4; i++)
        {
            Layer l = (layers != null && i < layers.Length) ? layers[i] : null;
            if (l == null) continue;
            if (l.albedo != null) block.SetTexture("_Splat" + i, l.albedo);
            if (l.normal != null) block.SetTexture("_Normal" + i, l.normal);
            block.SetVector("_Splat" + i + "_ST", new Vector4(l.tiling, l.tiling, 0f, 0f));
            block.SetFloat("_NormalScale" + i, l.normalScale);
            block.SetFloat("_Smoothness" + i, l.smoothness);
            block.SetFloat("_Metallic" + i, l.metallic);
        }
        r.SetPropertyBlock(block);
    }
}
