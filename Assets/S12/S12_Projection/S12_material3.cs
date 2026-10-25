using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S12_material3 : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] {
            new Vector3(0, 0.8f, 0),   // 위 꼭짓점
            new Vector3(-0.5f, 0, 0),  new Vector3(0, 0, -0.5f),
            new Vector3(0.5f, 0, 0),   new Vector3(0, 0, 0.5f),
            new Vector3(0, -0.8f, 0)  // 아래 꼭짓점
        };
        mesh.triangles = new int[] {
            0, 1, 2,  0, 2, 3,  0, 3, 4,  0, 4, 1, // 위쪽 뿔
            5, 2, 1,  5, 3, 2,  5, 4, 3,  5, 1, 4  // 아래쪽 뿔
        };
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;
    }
}