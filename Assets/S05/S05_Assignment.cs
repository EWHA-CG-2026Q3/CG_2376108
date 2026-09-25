using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class S05_MyMeshRenderer : MonoBehaviour
{
    [SerializeField] private int canvasWidth = 256;
    [SerializeField] private int canvasHeight = 256;
    [SerializeField] private Color backgroundColor = new Color(0f, 0f, 0f, 1f);

    [Header("무늬 실습 (줄무늬·체스판 공용)")]
    [SerializeField] private int patternSize = 16;
    [SerializeField] private Color colorA = new Color(1f, 1f, 1f, 1f); 
    [SerializeField] private Color colorB = new Color(0.3f, 0.5f, 0.8f, 1f); 

    private Texture2D canvasTexture;
    private RawImage targetImage;

    void Start()
    {
        targetImage = GetComponent<RawImage>();

        
        canvasTexture = new Texture2D(canvasWidth, canvasHeight);

        
        canvasTexture.filterMode = FilterMode.Point;

        // FillVerticalStripes(patternSize, colorA, colorB); // 줄무늬
        FillCheckerboard(patternSize, colorA, colorB);  // 체스판
        // -------------------------------------------------------------

        
        canvasTexture.Apply();

        
        targetImage.texture = canvasTexture;
    }

    
    private void FillVerticalStripes(int width, Color colorA, Color colorB)
    {
        for (int x = 0; x < canvasWidth; x++)
        {
            
            bool isColorA = (x / width) % 2 == 0;
            Color stripeColor = isColorA ? colorA : colorB;

            for (int y = 0; y < canvasHeight; y++)
            {
                canvasTexture.SetPixel(x, y, stripeColor);
            }
        }
    }

    
    private void FillCheckerboard(int size, Color colorA, Color colorB)
    {
        for (int x = 0; x < canvasWidth; x++)
        {
            for (int y = 0; y < canvasHeight; y++)
            {
                
                bool isColorA = ((x / size) + (y / size)) % 2 == 0;
                Color checkerColor = isColorA ? colorA : colorB;

                canvasTexture.SetPixel(x, y, checkerColor);
            }
        }
    }
}
