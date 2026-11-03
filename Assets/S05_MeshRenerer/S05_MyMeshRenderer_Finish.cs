using UnityEngine;
using UnityEngine.UI;

// S05_PixelCanvas_Finish
// 목적: Texture2D 기반 픽셀 캔버스를 생성하고, 단색/랜덤/줄무늬/체스판 무늬를 채운다.

public class S05_MyMeshRenderer_Finish : MonoBehaviour
{
    [SerializeField] private int canvasWidth = 256;
    [SerializeField] private int canvasHeight = 256;
    [SerializeField] private Color backgroundColor = new Color(0f, 0f, 0f, 1f); // 검정

    [Header("무늬 실습 (줄무늬·체스판 공용)")]
    [SerializeField] private int patternSize = 16;
    [SerializeField] private Color colorA = new Color(1f, 1f, 1f, 1f); // 흰색
    [SerializeField] private Color colorB = new Color(0.3f, 0.5f, 0.8f, 1f); // 직접 조합한 하늘색

    private Texture2D canvasTexture;
    private RawImage targetImage;

    void Start()
    {
        targetImage = GetComponent<RawImage>();

        // 1. 빈 캔버스(Texture2D) 생성 — 아직 아무 색도 채워지지 않은 상태
        canvasTexture = new Texture2D(canvasWidth, canvasHeight);

        // 2. 픽셀 경계를 흐리지 않게(확대해도 네모난 픽셀 그대로 보이도록)
        canvasTexture.filterMode = FilterMode.Point;

        // 3. 픽셀 채우기 (실습 단계에 따라 아래 호출을 교체)
        // FillBackground(backgroundColor);
        // FillRandom();
        // FillVerticalStripes(patternSize, colorA, colorB);
        FillCheckerboard(patternSize, colorA, colorB);

        // 4. 지금까지의 SetPixel 변경 사항을 실제로 텍스처에 반영
        canvasTexture.Apply();

        // 5. 완성된 텍스처를 화면의 RawImage에 연결
        targetImage.texture = canvasTexture;
    }

    // 참고 예시 ① — 캔버스 전체를 한 가지 색으로 채움 (모든 픽셀이 같은 값)
    private void FillBackground(Color color)
    {
        Debug.Log("FillBackground");
        for (int x = 0; x < canvasWidth; x++)
        {
            for (int y = 0; y < canvasHeight; y++)
            {
                canvasTexture.SetPixel(x, y, color);
            }
        }
    }

    // 참고 예시 ② — 각 픽셀을 독립적으로 무작위 색으로 채움 (픽셀마다 다른 값, 조건은 없음)
    private void FillRandom()
    {
        Debug.Log("FillRandom");
        for (int x = 0; x < canvasWidth; x++)
        {
            for (int y = 0; y < canvasHeight; y++)
            {
                Color randomColor = new Color(Random.value, Random.value, Random.value, 1f);
                canvasTexture.SetPixel(x, y, randomColor);
            }
        }
    }

    // 세로 줄무늬로 캔버스 채우기 (x좌표 기준)
    private void FillVerticalStripes(int width, Color colorA, Color colorB)
    {
        Debug.Log("FillVerticalStripes");
        for (int x = 0; x < canvasWidth; x++)
        {
            bool isColorA = (x / width) % 2 == 0;
            Color stripeColor = isColorA ? colorA : colorB;

            for (int y = 0; y < canvasHeight; y++)
                canvasTexture.SetPixel(x, y, stripeColor);
        }
    }

    // 체스판(checkerboard) 무늬로 캔버스 채우기
    private void FillCheckerboard(int size, Color colorA, Color colorB)
    {
        Debug.Log("FillCheckerboard");
        for (int x = 0; x < canvasWidth; x++)
        {
            for (int y = 0; y < canvasHeight; y++)
            {
                bool isColorA = ((x / size) + (y / size)) % 2 == 0;
                canvasTexture.SetPixel(x, y, isColorA ? colorA : colorB);
            }
        }
    }
}