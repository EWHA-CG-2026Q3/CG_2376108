using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S04_CustomCubeMesh : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();

        // 정점 좌표는 미리 제공됩니다 (면마다 4개씩, 총 24개)
        Vector3[] vertices = new Vector3[]
        {
            // 앞면 (+Z) — 0,1,2,3
            new Vector3(-0.5f,-0.5f, 0.5f), new Vector3(0.5f,-0.5f, 0.5f),
            new Vector3( 0.5f, 0.5f, 0.5f), new Vector3(-0.5f, 0.5f, 0.5f),
            // 뒷면 (-Z) — 4,5,6,7
            new Vector3( 0.5f,-0.5f,-0.5f), new Vector3(-0.5f,-0.5f,-0.5f),
            new Vector3(-0.5f, 0.5f,-0.5f), new Vector3( 0.5f, 0.5f,-0.5f),
            // 왼쪽면 (-X) — 8,9,10,11
            new Vector3(-0.5f,-0.5f,-0.5f), new Vector3(-0.5f,-0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(-0.5f, 0.5f,-0.5f),
            // 오른쪽면 (+X) — 12,13,14,15
            new Vector3(0.5f,-0.5f, 0.5f), new Vector3(0.5f,-0.5f,-0.5f),
            new Vector3(0.5f, 0.5f,-0.5f), new Vector3(0.5f, 0.5f, 0.5f),
            // 윗면 (+Y) — 16,17,18,19
            new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, 0.5f,-0.5f), new Vector3(-0.5f, 0.5f,-0.5f),
            // 아랫면 (-Y) — 20,21,22,23
            new Vector3(-0.5f,-0.5f,-0.5f), new Vector3(0.5f,-0.5f,-0.5f),
            new Vector3(0.5f,-0.5f, 0.5f), new Vector3(-0.5f,-0.5f, 0.5f),
        };

        // TODO: 각 면(4개 정점)을 삼각형 2개로 채우세요.
        // 힌트: 정사면체에서 배운 것처럼, 카메라 쪽에서 봤을 때
        // 시계 방향으로 정점을 감아야 그 면이 보입니다.
        // 예: 앞면(0,1,2,3)의 경우 → 0,?,? / 0,?,?  형태로 두 삼각형을 채워보세요.
        int[] triangles = new int[]
        {
            // 앞면 (0,1,2,3)

            // 뒷면 (4,5,6,7)

            // 왼쪽면 (8,9,10,11)

            // 오른쪽면 (12,13,14,15)

            // 윗면 (16,17,18,19)

            // 아랫면 (20,21,22,23)
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}

