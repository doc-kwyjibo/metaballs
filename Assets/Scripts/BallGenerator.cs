using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public int numberOfBalls;

    public GameObject ballPrefab;

    public float minSpeed;
    public float maxSpeed;

    public float minRadius;
    public float maxRadius;

    // Start is called before the first frame update
    void Start()
    {
        for (int n = 0; n < numberOfBalls; n++)
        {
            var ballGameObject = Instantiate(ballPrefab, transform);
            var ball = ballGameObject.GetComponent<Ball>();
            ball.speed = Random.Range(minSpeed, maxSpeed);
            ball.radius = Random.Range(minRadius, maxRadius);
        }

    }
}
