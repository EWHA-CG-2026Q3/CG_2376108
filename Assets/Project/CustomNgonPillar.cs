using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CustomNgonPillar : MonoBehaviour
{
    [Header("석등 형태 설정")]
    [SerializeField] private int sides = 6; 

    void Start()
    {
        GenerateLanternPillar();
    }

    void GenerateLanternPillar()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mesh.name = "DetailedLanternPillar";

      
        float[] radii = new float[] { 0.7f, 0.6f, 0.3f, 0.3f, 0.5f, 0.5f, 0.8f, 0.1f };
        float[] heights = new float[] { 0.0f, 0.2f, 0.3f, 1.5f, 1.6f, 2.0f, 2.1f, 2.5f };

        int ringCount = radii.Length;
        Vector3[] vertices = new Vector3[sides * ringCount];
        int[] triangles = new int[sides * (ringCount - 1) * 6];

        float angleStep = (2f * Mathf.PI) / sides;

        
        for (int r = 0; r < ringCount; r++)
        {
            float currentRadius = radii[r];
            float currentHeight = heights[r];

            for (int s = 0; s < sides; s++)
            {
                float angle = s * angleStep;
                float x = Mathf.Cos(angle) * currentRadius;
                float z = Mathf.Sin(angle) * currentRadius;

                vertices[r * sides + s] = new Vector3(x, currentHeight, z);
            }
        }

        
        int tIndex = 0;
        for (int r = 0; r < ringCount - 1; r++)
        {
            int currentRing = r * sides;
            int nextRing = (r + 1) * sides;

            for (int s = 0; s < sides; s++)
            {
                int nextS = (s + 1) % sides;

                int v1 = currentRing + s;
                int v2 = currentRing + nextS;
                int v3 = nextRing + s;
                int v4 = nextRing + nextS;

                
                triangles[tIndex++] = v1;
                triangles[tIndex++] = v3;
                triangles[tIndex++] = v2;

                triangles[tIndex++] = v2;
                triangles[tIndex++] = v3;
                triangles[tIndex++] = v4;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals(); 

        meshFilter.mesh = mesh;
    }
}