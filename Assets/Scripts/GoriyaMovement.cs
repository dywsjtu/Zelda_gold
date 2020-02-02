using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoriyaMovement : MonoBehaviour
{
    public float movement_speed = 1.0f;

    Rigidbody rb;
    Vector2[] direction = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
    public bool attack = false;
    int current_direction = 0;
    Animator animator;
    Coroutine current_move;
    BoomerangeFly boomerangeFly;
    bool back = false;

    // Start is called before the first frame update
    void Start()
    {
        boomerangeFly = GetComponent<BoomerangeFly>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        current_move = StartCoroutine(Move());
    }

    public Vector3 GetDirection()
    {
        // Vector3 result = new Vector3(direction[current_direction].x, direction[current_direction].y, 0);
        return direction[current_direction];
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (attack == false)
            {
                // int t = 10;
                // while (t > 0)
                // {
                //     t--;
                //     yield return 0;
                // }
                // Debug.Log(attack);
                current_direction = Random.Range(0, 4);
                Vector2 dir = direction[current_direction];
                float seed = Random.Range(0f, 1f);
                if (dir.x != 0)
                {
                    if (Mathf.Round(transform.position.y) != transform.position.y)
                    {
                        transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), transform.position.z);
                    }
                }
                if (dir.y != 0)
                {
                    if (Mathf.Round(transform.position.x) != transform.position.x)
                    {
                        transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
                    }
                }
                animator.SetFloat("horizontal", dir.x);
                animator.SetFloat("vertical", dir.y);
                if (seed < 0.8f)
                {
                    for (float moved = 0; moved < 1; moved += movement_speed * Time.deltaTime)
                    {
                        rb.velocity = dir * movement_speed;
                        yield return null;
                    }
                }
                else
                {
                    attack = true;
                    rb.velocity = Vector3.zero;
                    boomerangeFly.SetFly(true);
                }
                yield return null;
                // boomerangeFly.SetFly(false);
            }
            yield return null;
        }
    }

    // public bool GetAttack()
    // {
    //     return back;
    // }

    public void SetAttack(bool value)
    {
        attack = value;
    }

    // public bool GetBack()
    // {
    //     return back;
    // }

    public void SetBack(bool value)
    {
        back = value;
    }

    public void StartMove()
    {
        current_move = StartCoroutine(Move());
    }

    void OnTriggerEnter(Collider other)
    {
        StopCoroutine(current_move);
        current_move = StartCoroutine(Move());
    }
}
