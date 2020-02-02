using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelMovement : MonoBehaviour
{
    public float movement_speed = 1.0f;

    Rigidbody rb;

    Vector2[] direction = { Vector2.up, Vector2.down, Vector2.left, Vector2.right, Vector2.zero };

    Coroutine current_move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        current_move = StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            Vector2 dir = direction[Random.Range(0, 5)];
            // if (dir.x != 0)
            // {
            if (Mathf.Round(transform.position.y) != transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), transform.position.z);
            }
            // }
            // if (dir.y != 0)
            // {
            if (Mathf.Round(transform.position.x) != transform.position.x)
            {
                transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
            }
            // }
            for (float moved = 0; moved < 1; moved += movement_speed * Time.deltaTime)
            {
                rb.velocity = dir * movement_speed;
                yield return null;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        StopCoroutine(current_move);
        current_move = StartCoroutine(Move());
    }
}
