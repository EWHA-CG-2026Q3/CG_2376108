using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S03_CustomPolygonMesh : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();

        // 사각형 예시 (정점 4개)
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1f,  1f, 0f), // v0: 왼쪽 위
            new Vector3( 1f,  1f, 0f), // v1: 오른쪽 위
            new Vector3( 1f, -1f, 0f), // v2: 오른쪽 아래
            new Vector3(-1f, -1f, 0f)  // v3: 왼쪽 아래
        };

        // 삼각형 2개로 사각형을 채움 (정점 4개 → 삼각형 4-2=2개)
        int[] triangles = new int[]
        {
            0, 1, 2, // 삼각형 1: 왼쪽위 - 오른쪽위 - 오른쪽아래
            0, 2, 3  // 삼각형 2: 왼쪽위 - 오른쪽아래 - 왼쪽아래
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}