using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CustomPolygonMesh : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();

        // TODO 1: 원하는 다각형의 정점 좌표를 채우세요 (최소 4개)
        Vector3[] vertices = new Vector3[]
        {
            // 예: new Vector3(0f, 1f, 0f),
        };

        // TODO 2: 정점 3개씩 묶어 삼각형들을 구성하세요
        // (정점이 N개인 다각형은 삼각형 N-2개로 채울 수 있습니다)
        int[] triangles = new int[]
        {
            // 예: 0, 1, 2,
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}