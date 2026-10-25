using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S04_CustomDiamondMesh : MonoBehaviour
{
    void Start()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f),     // 0 (허리띠)
            new Vector3(1f, 0f, 0f),     // 1 (허리띠)
            new Vector3(1f, 0f, 1f),     // 2 (허리띠)
            new Vector3(0f, 0f, 1f),     // 3 (허리띠)
            new Vector3(0.5f, 1f, 0.5f),  // 4 (윗꼭짓점)
            new Vector3(0.5f, -1f, 0.5f), // 5 (아랫꼭짓점)
        };

        // 위쪽 4개 면, 아래쪽 4개 면을 시계방향 삼각형으로 구성
        int[] triangles = new int[]
        {
            // 위쪽 4개 면 (윗꼭짓점 4번과 연결)
            4, 1, 0,
            4, 2, 1,
            4, 3, 2,
            4, 0, 3,

            // 아래쪽 4개 면 (아랫꼭짓점 5번과 연결)
            5, 0, 1,
            5, 1, 2,
            5, 2, 3,
            5, 3, 0
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}