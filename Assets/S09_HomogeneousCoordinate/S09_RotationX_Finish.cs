using UnityEngine;

// 실습 정답: RotationZMatrixRaw()를 참고해 작성한 RotationXMatrixRaw()
// 확인: Transform의 Rotation x에 같은 각도를 넣은 다이아몬드와 겹치는지 비교
// (이 오브젝트의 Transform은 기본값 Position 0, Rotation 0, Scale 1을 유지)
[ExecuteAlways]
[RequireComponent(typeof(DiamondMesh))]
public class S09_RotationX_Finish : MonoBehaviour
{
    [SerializeField] float angle = 30f;   // x축 회전 각도, 도 단위

    DiamondMesh diamondMesh;

    void OnEnable()
    {
        diamondMesh = GetComponent<DiamondMesh>();
    }

    void Update()
    {
        if (diamondMesh == null || diamondMesh.BaseVertices == null) return;

        float[,] R = RotationXMatrixRaw(angle);
        Vector3[] baseVertices = diamondMesh.BaseVertices;
        Vector3[] verts = new Vector3[baseVertices.Length];
        for (int i = 0; i < baseVertices.Length; i++)
            verts[i] = FromHomogeneous(MultiplyMatrixVectorRaw(R, ToHomogeneous(baseVertices[i])));
        diamondMesh.SetVertices(verts);
    }

    // 참고: z축 회전 행렬 (e₃는 그대로, e₁과 e₂가 돎)
    float[,] RotationZMatrixRaw(float angleDegrees)
    {
        float rad = angleDegrees * Mathf.Deg2Rad;
        float c = Mathf.Cos(rad);
        float s = Mathf.Sin(rad);
        return new float[,] {
            { c,  -s,  0f, 0f },
            { s,   c,  0f, 0f },
            { 0f,  0f, 1f, 0f },
            { 0f,  0f, 0f, 1f }
        };
    }

    // x축 회전 행렬 (e₁은 그대로, e₂와 e₃가 돎)
    // 1열: e₁ → (1, 0, 0) / 2열: e₂ → (0, c, s) / 3열: e₃ → (0, −s, c) / 4열: 원점 그대로
    float[,] RotationXMatrixRaw(float angleDegrees)
    {
        float rad = angleDegrees * Mathf.Deg2Rad;
        float c = Mathf.Cos(rad);
        float s = Mathf.Sin(rad);
        return new float[,] {
            { 1f, 0f,  0f, 0f },
            { 0f, c,  -s,  0f },
            { 0f, s,   c,  0f },
            { 0f, 0f,  0f, 1f }
        };
    }

    // 정점에 네 번째 성분 1을 붙임
    Vector4 ToHomogeneous(Vector3 v)
    {
        return new Vector4(v.x, v.y, v.z, 1f);
    }

    // 계산이 끝난 뒤 네 번째 성분을 떼어냄
    Vector3 FromHomogeneous(Vector4 h)
    {
        return new Vector3(h.x, h.y, h.z);
    }

    // 4×4 행렬-벡터 곱
    Vector4 MultiplyMatrixVectorRaw(float[,] M, Vector4 v)
    {
        float[] input = { v.x, v.y, v.z, v.w };
        float[] result = new float[4];
        for (int row = 0; row < 4; row++)
            for (int col = 0; col < 4; col++)
                result[row] += M[row, col] * input[col]; // 행과 벡터의 내적
        return new Vector4(result[0], result[1], result[2], result[3]);
    }
}