using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S04_CustomCubeMesh : MonoBehaviour
{
    void Start()
    {
        // 정육면체 8개 정점
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f), // 0
            new Vector3(1f, 0f, 0f), // 1
            new Vector3(1f, 1f, 0f), // 2
            new Vector3(0f, 1f, 0f), // 3
            new Vector3(0f, 0f, 1f), // 4
            new Vector3(1f, 0f, 1f), // 5
            new Vector3(1f, 1f, 1f), // 6
            new Vector3(0f, 1f, 1f), // 7
        };

        // 6개 면을 삼각형 2개씩(총 12개) 구성
        int[] triangles = new int[]
        {
            // z=0 면 (앞면)
            0, 2, 1,   0, 3, 2,

            // z=1 면 (뒷면)
            4, 5, 6,   4, 6, 7,

            // y=0 면 (아랫면)
            0, 1, 5,   0, 5, 4,

            // y=1 면 (윗면)
            3, 6, 2,   3, 7, 6,

            // x=0 면 (왼쪽면)
            0, 4, 7,   0, 7, 3,

            // x=1 면 (오른쪽면)
            1, 2, 6,   1, 6, 5
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}