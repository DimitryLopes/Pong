using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCooldown : MonoBehaviour
{
    private Collider2D collider;
    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        StartCoroutine(EnableCollider());
    }

    private IEnumerator EnableCollider()
    {
        collider.enabled = false;
        float timer = 0;
        while(timer <= 0.2f)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        collider.enabled = true;
    }
}
