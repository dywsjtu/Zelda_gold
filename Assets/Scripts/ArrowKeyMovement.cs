using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour
{
    public float movement_speed = 4.0f;
    public int dir = 0;
    public bool is_moving = false;

    Rigidbody rb;

    bool disabled = false;

    public void Disable()
    {
        disabled = true;
    }

    public void Enable()
    {
        disabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled == true)
        {
            return;
        }

        Vector2 current_input = GetInput();

        if (current_input.x != 0)
        {
            if (current_input.x < 0)
            {
                dir = 2;
            }
            else
            {
                dir = 3;
            }

            if (Mathf.Round(transform.position.y * 2) != transform.position.y * 2)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y * 2) / 2, transform.position.z);
            }
        }
        if (current_input.y != 0)
        {
            if (current_input.y < 0)
            {
                dir = 1;
            }
            else
            {
                dir = 0;
            }

            if (Mathf.Round(transform.position.x * 2) != transform.position.x * 2)
            {
                transform.position = new Vector3(Mathf.Round(transform.position.x * 2) / 2, transform.position.y, transform.position.z);
            }
        }

        // rb.velocity = current_input * movement_speed;
        if (current_input != Vector2.zero)
        {
            is_moving = true;
            rb.MovePosition((Vector2)transform.position + current_input * movement_speed * Time.deltaTime);
        }
        else
        {
            is_moving = false;
        }
    }

    public Vector2 GetInput()
    {
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(horizontal_input) > 0.0f)
        {
            vertical_input = 0.0f;
        }
        // if (Mathf.Abs(vertical_input) > 0.0f)
        // {
        //     horizontal_input = 0.0f;
        // }

        return new Vector2(horizontal_input, vertical_input);
    }
}
