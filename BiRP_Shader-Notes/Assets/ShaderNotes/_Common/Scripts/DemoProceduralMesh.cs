using UnityEngine;

namespace ShaderStudy
{
    /// <summary>
    /// Generates a mesh for the MeshFilter in edit and play mode (it is never saved to disk):
    /// - Grid: a subdivided quad (needed by vertex-displacement shaders such as the butterfly/fish).
    /// - CopyWithVertexColors: a copy of another mesh with explicit white vertex colours, for shaders
    ///   that read the vertex colour alpha (normally provided by particle systems).
    /// </summary>
    [ExecuteAlways]
    [RequireComponent(typeof(MeshFilter))]
    public class DemoProceduralMesh : MonoBehaviour
    {
        public enum Kind { Grid, CopyWithVertexColors }
        public enum Plane { XY, XZ }

        public Kind kind = Kind.Grid;

        [Header("Grid")]
        public Plane plane = Plane.XY;
        public Vector2 size = Vector2.one;
        public Vector2Int segments = new Vector2Int(20, 4);

        [Header("Copy")]
        public Mesh sourceMesh;
        public Color vertexColor = Color.white;

        private Mesh generated;

        private void OnEnable()
        {
            Build();
        }

        private void OnDisable()
        {
            if (generated != null)
            {
                if (Application.isPlaying) Destroy(generated); else DestroyImmediate(generated);
                generated = null;
            }
        }

        public void Build()
        {
            if (generated == null)
            {
                generated = new Mesh { name = "Generated (" + name + ")", hideFlags = HideFlags.HideAndDontSave };
            }
            generated.Clear();
            if (kind == Kind.Grid) BuildGrid(generated); else BuildCopy(generated);
            GetComponent<MeshFilter>().sharedMesh = generated;
        }

        private void BuildGrid(Mesh m)
        {
            int sx = Mathf.Max(1, segments.x), sy = Mathf.Max(1, segments.y);
            int count = (sx + 1) * (sy + 1);
            var vertices = new Vector3[count];
            var uvs = new Vector2[count];
            var normals = new Vector3[count];
            var colors = new Color[count];
            Vector3 normal = plane == Plane.XY ? Vector3.back : Vector3.up;
            for (int y = 0; y <= sy; y++)
            {
                for (int x = 0; x <= sx; x++)
                {
                    int i = y * (sx + 1) + x;
                    float u = (float)x / sx, v = (float)y / sy;
                    float px = (u - 0.5f) * size.x, py = (v - 0.5f) * size.y;
                    vertices[i] = plane == Plane.XY ? new Vector3(px, py, 0f) : new Vector3(px, 0f, py);
                    uvs[i] = new Vector2(u, v);
                    normals[i] = normal;
                    colors[i] = vertexColor;
                }
            }
            var tris = new int[sx * sy * 6];
            int t = 0;
            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    int i = y * (sx + 1) + x;
                    tris[t++] = i; tris[t++] = i + sx + 1; tris[t++] = i + 1;
                    tris[t++] = i + 1; tris[t++] = i + sx + 1; tris[t++] = i + sx + 2;
                }
            }
            m.vertices = vertices;
            m.uv = uvs;
            m.normals = normals;
            m.colors = colors;
            m.triangles = tris;
            m.RecalculateTangents();
            m.RecalculateBounds();
        }

        private void BuildCopy(Mesh m)
        {
            if (sourceMesh == null) return;
            m.vertices = sourceMesh.vertices;
            m.normals = sourceMesh.normals;
            m.tangents = sourceMesh.tangents;
            m.uv = sourceMesh.uv;
            m.subMeshCount = sourceMesh.subMeshCount;
            for (int s = 0; s < sourceMesh.subMeshCount; s++) m.SetTriangles(sourceMesh.GetTriangles(s), s);
            var colors = new Color[sourceMesh.vertexCount];
            for (int i = 0; i < colors.Length; i++) colors[i] = vertexColor;
            m.colors = colors;
            m.RecalculateBounds();
        }
    }
}
