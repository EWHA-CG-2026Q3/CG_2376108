using UnityEngine;

public class S04_Assignment : MonoBehaviour
{
    void Start()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, -1f, 0f),
            new Vector3(0f, 0f, -1f),
            new Vector3(1f, 0f, 0f),
            new Vector3(0f, 0f, 1f)
            new Vector3(-1f, 0f, 0f)

        };

        // TODO 2: 정점 3개씩 묶어 삼각형들을 구성하세요
        int[] triangles = new int[]
        {
            0, 3, 2,
            0, 4, 3,
            0, 5, 4,
            0, 2, 5,

            1, 2, 3,
            1, 3, 4,
            1, 4, 5,
            1, 5, 2
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Sprites/Default"));
    }
}