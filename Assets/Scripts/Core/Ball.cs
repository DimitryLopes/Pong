using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Transform ballSpawnPoint;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float baseSpeed;
    [SerializeField]
    private float speedIncreaseFactor;
    private float speed;
    public void ResetPosition()
    {
        speed = baseSpeed;
        transform.position = ballSpawnPoint.position;
        int right = Random.Range(0, 2);
        float angle;
        if (right > 0)
        {
            angle = GetRandomAngle(135f, 225f);
        }
        else
        {
            angle = GetRandomAngle(45f, -45f);
        }
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        rb.velocity = direction * speed;
    }
    float GetRandomAngle(float minAngle, float maxAngle)
    {
        return Random.Range(minAngle, maxAngle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            speed += speedIncreaseFactor;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y).normalized * speed;
        }
    }
}
