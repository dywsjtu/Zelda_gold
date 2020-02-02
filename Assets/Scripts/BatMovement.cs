using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public float movement_speed = 2.0f;

    Rigidbody rb;

    Coroutine current_move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        current_move = StartCoroutine(Move());
        StartCoroutine(Invisible());
    }

    IEnumerator Move()
    {
        while (true)
        {
            Vector2 dir = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            if (dir != Vector2.zero)
            {
                for (float moved = 0; moved < 1; moved += movement_speed * Time.deltaTime)
                {
                    rb.velocity = dir * movement_speed;
                    yield return null;
                }
            }
            else
            {
                for (float moved = 0; moved < 1; moved += movement_speed * Time.deltaTime)
                {
                    rb.velocity = Vector3.zero;
                    yield return null;
                }
            }
        }
    }

    IEnumerator Invisible()
    {
        while (true)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
            float duration = Random.Range(1.0f, 2.0f);
            float initial_time = Time.time;
            float progress = (Time.time - initial_time) / duration;
            while (progress < 1.0f)
            {
                progress = (Time.time - initial_time) / duration;
                yield return null;
            }
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
            duration = Random.Range(2.0f, 3.0f);
            initial_time = Time.time;
            progress = (Time.time - initial_time) / duration;
            while (progress < 1.0f)
            {
                progress = (Time.time - initial_time) / duration;
                yield return null;
            }
            yield return null;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        StopCoroutine(current_move);
        current_move = StartCoroutine(Move());
    }
}
