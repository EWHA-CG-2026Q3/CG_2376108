using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class PixelArtFrame : MonoBehaviour
{
    [Header("픽셀 아트 캔버스 설정")]
    [SerializeField] private int width = 64;   
    [SerializeField] private int height = 64;
    [SerializeField] private int tileSize = 16; 

    [Header("단청 색상 팔레트")]
    [SerializeField] private Color redColor = new Color(0.65f, 0.12f, 0.12f);   
    [SerializeField] private Color greenColor = new Color(0.08f, 0.42f, 0.28f); 
    [SerializeField] private Color yellowColor = new Color(0.85f, 0.65f, 0.15f); 
    [SerializeField] private Color blueColor = new Color(0.12f, 0.22f, 0.45f);  
    [SerializeField] private Color bgColor = new Color(0.1f, 0.1f, 0.12f);     

    void Start()
    {
        GenerateDancheongPattern();
    }

    void GenerateDancheongPattern()
    {
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point; 

       
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                
                int localX = x % tileSize;
                int localY = y % tileSize;

                
                if (localX == 0 || localY == 0 || localX == tileSize - 1 || localY == tileSize - 1)
                {
                    texture.SetPixel(x, y, yellowColor);
                    continue;
                }

                
                float cx = tileSize / 2f - 0.5f;
                float cy = tileSize / 2f - 0.5f;
                float dx = localX - cx;
                float dy = localY - cy;
                float dist = Mathf.Sqrt(dx * dx + dy * dy);

                Color pixelColor;

                if (dist < 1.8f)
                {
                    pixelColor = yellowColor; 
                }
                else if (dist < 3.8f)
                {
                    pixelColor = redColor;    
                }
                else if (dist < 5.8f)
                {
                    pixelColor = greenColor;  
                }
                else if (dist < 7.2f)
                {
                    pixelColor = blueColor;   
                }
                else
                {
                    pixelColor = bgColor;     
                }

                texture.SetPixel(x, y, pixelColor);
            }
        }

        texture.Apply();

        
        Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        mat.mainTexture = texture;

        
        mat.EnableKeyword("_EMISSION");
        mat.SetTexture("_EmissionMap", texture);
        mat.SetColor("_EmissionColor", Color.white * 0.25f);

        GetComponent<MeshRenderer>().material = mat;
    }
}