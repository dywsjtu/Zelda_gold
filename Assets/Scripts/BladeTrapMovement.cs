using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTrapMovement : MonoBehaviour
{
    public float offset_x_min;
    public float offset_x_max;
    public float offset_y_min;
    public float offset_y_max;
    public float to_speed = 4.0f;
    public float back_speed = 1.0f;
    public GameObject player;

    private bool is_back = true;
    private Vector3 original;

    Coroutine current_move;

    // Start is called before the first frame update
    void Start()
    {
        original = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_back)
        {
            if (Mathf.Abs(player.transform.position.x - transform.position.x) <= 0.5f && player.transform.position.y - transform.position.y >= offset_y_min && player.transform.position.y - transform.position.y <= offset_y_max)
            {
                is_back = false;
                current_move = StartCoroutine(MoveVertical());
            }
            if (Mathf.Abs(player.transform.position.y - transform.position.y) <= 0.5f && player.transform.position.x - transform.position.x >= offset_x_min && player.transform.position.x - transform.position.x <= offset_x_max)
            {
                is_back = false;
                current_move = StartCoroutine(MoveHorizontal());
            }
        }
    }

    IEnumerator MoveVertical()
    {
        Vector3 final_position = original + new Vector3(0, offset_y_min + 3, 0);

        float initial_time = Time.time;
        float progress = (Time.time - initial_time) * to_speed;
        while (progress < 1.0f)
        {
            progress = (Time.time - initial_time) * to_speed;
            Vector3 new_position = Vector3.Lerp(original, final_position, progress);
            transform.position = new_position;
            yield return null;
        }
        transform.position = final_position;

        initial_time = Time.time;
        progress = (Time.time - initial_time) * back_speed;
        while (progress < 1.0f)
        {
            progress = (Time.time - initial_time) * back_speed;
            Vector3 new_position = Vector3.Lerp(final_position, original, progress);
            transform.position = new_position;

            yield return null;
        }
        transform.position = original;

        is_back = true;
    }

    IEnumerator MoveHorizontal()
    {
        Vector3 final_position = original + new Vector3(offset_x_min + 5.5f, 0, 0);

        float initial_time = Time.time;
        float progress = (Time.time - initial_time) * to_speed;
        while (progress < 1.0f)
        {
            progress = (Time.time - initial_time) * to_speed;
            Vector3 new_position = Vector3.Lerp(original, final_position, progress);
            transform.position = new_position;
            yield return null;
        }
        transform.position = final_position;

        initial_time = Time.time;
        progress = (Time.time - initial_time) * back_speed;
        while (progress < 1.0f)
        {
            progress = (Time.time - initial_time) * back_speed;
            Vector3 new_position = Vector3.Lerp(final_position, original, progress);
            transform.position = new_position;

            yield return null;
        }
        transform.position = original;

        is_back = true;
    }

    IEnumerator MoveBack()
    {
        Vector3 current_position = transform.position;
        float initial_time = Time.time;
        float progress = (Time.time - initial_time) * back_speed;
        while (progress < 1.0f)
        {
            progress = (Time.time - initial_time) * back_speed;
            Vector3 new_position = Vector3.Lerp(current_position, original, progress);
            transform.position = new_position;
            yield return null;
        }
        transform.position = original;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine(current_move);
            StartCoroutine(MoveBack());
        }
    }
}
