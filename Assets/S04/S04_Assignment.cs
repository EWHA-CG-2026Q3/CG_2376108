using UnityEngine;

public class S04_Assignment : MonoBehaviour
{
    void Start()
    {
        // TODO 1: 원하는 다각형의 정점 좌표를 채우세요 (최소 4개)
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 2.5f, 0f),
            new Vector3(-1.5f, 1f, 0f),
            new Vector3(-1.5f, -1.5f, 0f),
            new Vector3(1.5f, -1.5f, 0f),
            new Vector3(1.5f, 1f, 0f)

        };

        // TODO 2: 정점 3개씩 묶어 삼각형들을 구성하세요
        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3,
            0, 3, 4
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Sprites/Default"));
    }
}