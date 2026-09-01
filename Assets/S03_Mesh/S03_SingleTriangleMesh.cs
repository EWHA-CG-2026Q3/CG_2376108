using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S03_SingleTriangleMesh : MonoBehaviour
{
    void OnEnable()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[3]
        {
            new Vector3(0f, 1f, 0f),
            new Vector3(-1f, -1f, 0f),
            new Vector3(1f, -1f, 0f)
        };

        int[] triangles = new int[3] { 0, 1, 2 }; // winding order 수정
        //int[] triangles = new int[3] { 0, 2, 1 }; // winding order 수정

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}