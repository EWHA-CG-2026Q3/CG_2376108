
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(DiamondMesh))]
public class S09_ShearMatrixRaw : MonoBehaviour
{
    [SerializeField] float k = 1f;

    DiamondMesh diamondMesh;

    void OnEnable()
    {
        diamondMesh = GetComponent<DiamondMesh>();
        ApplyShear();
    }

    void Update()
    {
        ApplyShear();
    }

    void OnValidate()
    {
        if (diamondMesh == null)
            diamondMesh = GetComponent<DiamondMesh>();

        if (diamondMesh != null)
            ApplyShear();
    }

    // 전단 변환 행렬
    float[,] ShearMatrixRaw(float k)
    {
        return new float[,]
        {
            { 1f, k,   0f, 0f },
            { 0f, 1f, 0f,   0f },
            { 0f, 0f, 1f,   0f },
            { 0f, 0f, 0f,   1f }
        };
    }

    // 동차좌표로 변환
    Vector4 ToHomogeneous(Vector3 v)
    {
        return new Vector4(v.x, v.y, v.z, 1f);
    }

    // 4×4 행렬과 벡터의 곱
    Vector4 MultiplyMatrixVectorRaw(float[,] M, Vector4 v)
    {
        float[] input = { v.x, v.y, v.z, v.w };
        float[] result = new float[4];

        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                result[row] += M[row, col] * input[col];
            }
        }

        return new Vector4(
            result[0], result[1], result[2], result[3]
        );
    }

    // 모든 정점에 전단 변환 적용
    Vector3[] ApplyShearRaw(Vector3[] baseVertices, float k)
    {
        float[,] H = ShearMatrixRaw(k);
        Vector3[] verts = new Vector3[baseVertices.Length];

        for (int i = 0; i < baseVertices.Length; i++)
        {
            Vector4 h = ToHomogeneous(baseVertices[i]);
            h = MultiplyMatrixVectorRaw(H, h);

            verts[i] = new Vector3(h.x, h.y, h.z);
        }

        return verts;
    }

    void ApplyShear()
    {
        if (diamondMesh == null ||
            diamondMesh.BaseVertices == null)
            return;

        Vector3[] verts =
            ApplyShearRaw(diamondMesh.BaseVertices, k);

        diamondMesh.SetVertices(verts);
    }

    // 꼭대기 정점의 변환 결과 출력
    [ContextMenu("Print Shear Result")]
    void PrintShearResult()
    {
        Vector3 top = new Vector3(0.5f, 1f, 0.5f);
        Vector4 h = MultiplyMatrixVectorRaw(
            ShearMatrixRaw(k), ToHomogeneous(top));

        Debug.Log(
            $"k = {k}, 꼭대기 정점 변환 결과 = " +
            $"({h.x}, {h.y}, {h.z})"
        );
    }
}
