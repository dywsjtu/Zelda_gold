using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquamentusMovement : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody rb;
    public GameObject fireball;
    private Vector3 direction;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        direction = Vector3.left;
        StartCoroutine(Move());
        StartCoroutine(Attack());
    }

    IEnumerator Move()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(2);

            // if (Mathf.Round(transform.position.y) != transform.position.y)
            // {
            //     transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), transform.position.z);
            // }
            if (Mathf.Round(transform.position.x) != transform.position.x)
            {
                transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
            }
            direction = -direction;
        }
    }

    IEnumerator Attack()
    {
        while (gameObject.activeSelf)
        {
            Vector3 mid_pos = transform.position;
            Vector3 player_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
            // Vector3 top_pos = player_pos;
            // Vector3 bot_pos = player_pos;
            // top_pos.y += 20f;
            // bot_pos.y -= 20f;
            Vector3 mid_dir = (player_pos - mid_pos).normalized;
            // Vector3 top_dir = (top_pos - mid_pos).normalized;
            // Vector3 bot_dir = (bot_pos - mid_pos).normalized;
            GameObject mid_ball = Instantiate(fireball, mid_pos, Quaternion.identity);
            mid_ball.GetComponent<FireBall>().direction = mid_dir;

            yield return new WaitForSeconds(3f);
        }
    }

    void Update()
    {
        rb.velocity = speed * direction;
    }
}
