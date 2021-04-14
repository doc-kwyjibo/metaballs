using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureCanvas : MonoBehaviour
{

    public int width;
    public int height;

    public Renderer textureRenderer;


    void Start()
    {
        /*
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var greyScale = Random.value;

                var colour = Color.Lerp(Color.black, Color.white, greyScale);

                texture.SetPixel(x, y, colour);
            }
        }

        texture.Apply();

        textureRenderer.sharedMaterial.mainTexture = texture;*/
    }

    public void DrawTexture(float[,] textureShades)
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var hue = ((30f*textureShades[x,y]) % 360) / 360f;

                var colour = Color.HSVToRGB(hue, 1, 1);

                texture.SetPixel(x, y, colour);
            }
        }

        texture.Apply();

        textureRenderer.sharedMaterial.mainTexture = texture;
    }
}
