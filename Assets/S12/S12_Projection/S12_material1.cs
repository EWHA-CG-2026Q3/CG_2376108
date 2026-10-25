using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S12_material1 : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] {
            new Vector3(-0.5f, 0, -0.5f), new Vector3(0.5f, 0, -0.5f),
            new Vector3(0.5f, 0, 0.5f),   new Vector3(-0.5f, 0, 0.5f),
            new Vector3(0, 1f, 0) // 피라미드 꼭짓점
        };
        mesh.triangles = new int[] {
            0, 1, 4,  1, 2, 4,  2, 3, 4,  3, 0, 4, // 옆면 4개
            0, 2, 1,  0, 3, 2  // 바닥면
        };
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
