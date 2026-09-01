using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S04_CustomTetrahedronMesh_Finish : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 1f, 0f),          // 0: 꼭짓점(apex)
            new Vector3(0f, -0.5f, 1f),       // 1: 밑면 앞
            new Vector3(0.87f, -0.5f, -0.5f), // 2: 밑면 오른쪽 뒤
            new Vector3(-0.87f, -0.5f, -0.5f) // 3: 밑면 왼쪽 뒤
        };

        int[] triangles = new int[]
        {
            1, 3, 2,  // 밑면
            0, 1, 2,  // 옆면 A
            0, 2, 3,  // 옆면 B
            0, 3, 1,  // 옆면 C
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}