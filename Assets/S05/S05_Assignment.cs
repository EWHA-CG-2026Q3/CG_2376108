using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class S05_MyMeshRenderer : MonoBehaviour
{
    [SerializeField] private int canvasWidth = 256;
    [SerializeField] private int canvasHeight = 256;
    [SerializeField] private Color backgroundColor = new Color(0f, 0f, 0f, 1f);

    [Header("무늬 실습 (줄무늬·체스판 공용)")]
    [SerializeField] private int patternSize = 4;
    [SerializeField] private Color colorA = new Color(1f, 1f, 1f, 1f); // 흰색
    [SerializeField] private Color colorB = new Color(0.3f, 0.5f, 0.8f, 1f); // 하늘색

    private Texture2D canvasTexture;
    private RawImage targetImage;

    void Start()
    {
        targetImage = GetComponent<RawImage>();

        
        canvasTexture = new Texture2D(canvasWidth, canvasHeight);

        
        canvasTexture.filterMode = FilterMode.Point;

        FillVerticalStripes(patternSize, colorA, colorB); // 줄무늬
        // FillCheckerboard(patternSize, colorA, colorB);  // 체스판
        // -------------------------------------------------------------

        
        canvasTexture.Apply();

        
        targetImage.texture = canvasTexture;
    }

    // 과제 2: 세로 줄무늬 생성 함수 (조건식 구현)
    private void FillVerticalStripes(int width, Color colorA, Color colorB)
    {
        for (int x = 0; x < canvasWidth; x++)
        {
            // x를 width로 나눈 몫이 짝수이면 colorA, 홀수이면 colorB
            bool isColorA = (x / width) % 2 == 0;
            Color stripeColor = isColorA ? colorA : colorB;

            for (int y = 0; y < canvasHeight; y++)
            {
                canvasTexture.SetPixel(x, y, stripeColor);
            }
        }
    }

    // 과제 3: 체스판 무늬 생성 함수 (x, y 혼합 조건식 및 SetPixel 구현)
    private void FillCheckerboard(int size, Color colorA, Color colorB)
    {
        for (int x = 0; x < canvasWidth; x++)
        {
            for (int y = 0; y < canvasHeight; y++)
            {
                // x와 y의 타일 위치를 더해서 짝수면 colorA, 홀수면 colorB
                bool isColorA = ((x / size) + (y / size)) % 2 == 0;
                Color checkerColor = isColorA ? colorA : colorB;

                canvasTexture.SetPixel(x, y, checkerColor);
            }
        }
    }
}
