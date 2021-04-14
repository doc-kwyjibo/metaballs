using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaballGenerator : MonoBehaviour
{

    TextureCanvas canvas;

    Ball[] balls;

    // Start is called before the first frame update
    void Start()
    {
        balls = FindObjectsOfType<Ball>();
        canvas = FindObjectOfType<TextureCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        var width = canvas.width;
        var height = canvas.height;

        const float planeFactor = 5f;

        var centre = canvas.transform.position;
        var scale = canvas.transform.localScale;

        var minX = centre.x - planeFactor * scale.x;
        var maxX = centre.x + planeFactor * scale.x;
        var minY = centre.y - planeFactor * scale.y;
        var maxY = centre.y + planeFactor * scale.y;

        float[,] distances = new float[width,height];

        float minAccumulation = float.MaxValue;
        float maxAccumulation = float.MinValue;

        for (int i = 0; i < width; i++)
        {
            var x = Mathf.Lerp(minX, maxX, ((float)i) / width);
            for (int j = 0; j < height; j++)
            {
                var y = Mathf.Lerp(minY, maxY, ((float)j) / height);

                float accumulation = 0;
                foreach (var ball in balls)
                {
                    // distance calc
                    var pixelPosition = new Vector3(x, y, 0);
                    var distance = (pixelPosition - ball.gameObject.transform.position).sqrMagnitude;

                    distance = Mathf.Clamp(distance, 0.1f, 10f);

                    accumulation += (3f * ball.radius) / distance;
                }

                distances[i, j] = accumulation;
                if (accumulation < minAccumulation)
                {
                    minAccumulation = accumulation;
                }
                if (accumulation > maxAccumulation)
                {
                    maxAccumulation = accumulation;
                }
            }
        }

        Debug.Log("Min: " + minAccumulation);
        Debug.Log("Max: " + maxAccumulation);

        /*
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                distances[x, y] = Mathf.InverseLerp(minAccumulation, maxAccumulation, distances[x, y]);
            }
        }
        */

        canvas.DrawTexture(distances);
    }
}
