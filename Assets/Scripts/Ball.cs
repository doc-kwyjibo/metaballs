using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;

public class Ball : MonoBehaviour
{

    public float speed;
    public float radius;

    Bounds bounds;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        var halfHeight = Camera.main.orthographicSize;
        var aspectRatio = Camera.main.aspect;

        var planeSize = new Vector3(aspectRatio * halfHeight, halfHeight, 0);

        bounds = new Bounds(Vector3.zero, planeSize*2f);

        var angle = Random.Range(-Mathf.PI, Mathf.PI);

        var velocity = new Vector2(speed * Mathf.Cos(angle), speed * Mathf.Sin(angle));

        rigidBody.velocity = velocity;

        transform.localScale = Vector3.one * radius;
    }

    private void Update()
    {
        var position = transform.position;

        var centre = bounds.center;
        var halfSize = bounds.extents;

        if (position.x < centre.x - halfSize.x || position.x > centre.x + halfSize.x)
        {
            var clampedXPosition = Mathf.Clamp(position.x, centre.x - halfSize.x, centre.x + halfSize.x);
            position.x = clampedXPosition;
            transform.position = position;

            var velocity = rigidBody.velocity;
            velocity.x *= -1;
            rigidBody.velocity = velocity;
        }

        if (position.y < centre.y - halfSize.y || position.y > centre.y + halfSize.y)
        {
            var clampedYPosition = Mathf.Clamp(position.y, centre.y - halfSize.y, centre.y + halfSize.y);
            position.y = clampedYPosition;
            transform.position = position;

            var velocity = rigidBody.velocity;
            velocity.y *= -1;
            rigidBody.velocity = velocity;
        }
    }
}
