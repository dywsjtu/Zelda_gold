using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeseMovement : MonoBehaviour
{
    public float movement_speed = 2.0f;

    Rigidbody rb;

    Animator animator;

    Coroutine current_move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        current_move = StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            Vector2 dir = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            if (dir != Vector2.zero)
            {
                animator.SetBool("isMoving", true);
                for (float moved = 0; moved < 1; moved += movement_speed * Time.deltaTime)
                {
                    rb.velocity = dir * movement_speed;
                    yield return null;
                }
            }
            else
            {
                animator.SetBool("isMoving", false);
                for (float moved = 0; moved < 1; moved += movement_speed * Time.deltaTime)
                {
                    rb.velocity = Vector3.zero;
                    yield return null;
                }
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        StopCoroutine(current_move);
        animator.SetBool("isMoving", false);
        current_move = StartCoroutine(Move());
    }
}
