using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S12_material2 : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] {
            new Vector3(-0.5f, 0, -0.5f), new Vector3(0.5f, 0, -0.5f), new Vector3(0, 0, 0.5f), // 밑면
            new Vector3(-0.5f, 1f, -0.5f), new Vector3(0.5f, 1f, -0.5f), new Vector3(0, 1f, 0.5f) // 윗면
        };
        mesh.triangles = new int[] {
            0, 2, 1,  3, 4, 5, // 바닥 & 윗면
            0, 1, 4,  0, 4, 3, // 옆면 1
            1, 2, 5,  1, 5, 4, // 옆면 2
            2, 0, 3,  2, 3, 5  // 옆면 3
        };
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;
    }
}