using UnityEngine;

// S8-S12 공용 지속 오브젝트 — 다이아몬드(위/아래 사각뿔을 맞붙인 bipyramid, 6정점)
// S04 출석인정과제의 정답이기도 함.
// 이 스크립트는 메시를 만들고 보관하는 역할만 함 — 이동/회전/스케일 계산은 별도 스크립트(S08_DirectVertexTransform 등)가 담당.

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class DiamondMesh : MonoBehaviour
{
    [Header("다이아몬드 원본 정점 (0=아래 꼭짓점, 1~4=중간 사각형, 5=위 꼭짓점)")]
    [SerializeField]
    Vector3[] baseVertices = new Vector3[]
    {
        new Vector3(0.5f, 0f, 0.5f),   // 0번 — 아래 꼭짓점
        new Vector3(0f,   0.5f, 0f),   // 1번 — 중간 사각형
        new Vector3(1f,   0.5f, 0f),   // 2번 — 중간 사각형
        new Vector3(1f,   0.5f, 1f),   // 3번 — 중간 사각형
        new Vector3(0f,   0.5f, 1f),   // 4번 — 중간 사각형
        new Vector3(0.5f, 1f,   0.5f), // 5번 — 위 꼭짓점
    };

    [SerializeField]
    int[] triangles = new int[]
    {
        // 아래쪽 4개 면 (0번 꼭짓점 기준)
        0, 1, 2,
        0, 2, 3,
        0, 3, 4,
        0, 4, 1,
        // 위쪽 4개 면 (5번 꼭짓점 기준)
        5, 2, 1,
        5, 3, 2,
        5, 4, 3,
        5, 1, 4,
    };

    Mesh mesh;

    // 원본 정점 배열 — 변환 스크립트가 매 프레임 이 값을 읽어와 계산의 기준으로 사용함
    public Vector3[] BaseVertices => baseVertices;

    void Awake()
    {
        SetupMesh();
    }

    void OnEnable()
    {
        if (mesh == null) SetupMesh();
    }

    void SetupMesh()
    {
        mesh = new Mesh();
        mesh.vertices = baseVertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    // 변환 스크립트가 계산을 마친 새 정점 배열을 여기로 전달하면, 실제 메시에 반영됨
    public void SetVertices(Vector3[] newVertices)
    {
        mesh.vertices = newVertices;
        mesh.RecalculateBounds();
    }
}