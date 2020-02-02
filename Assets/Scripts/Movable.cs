using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public GameObject player;
    public float duration = 1.5f;
    public Vector3 offset = new Vector3(-1, 0, 0);
    public int dir = 2;

    private float collision_time = 0;
    public bool is_moved = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(collision_time);
    }

    void OnCollisionEnter(Collision other)
    {

    }

    void OnCollisionStay(Collision other)
    {
        if (is_moved == false && player.GetComponent<ArrowKeyMovement>().is_moving == true && player.GetComponent<ArrowKeyMovement>().dir == dir)
        {
            collision_time += Time.deltaTime;
        }
        else
        {
            collision_time = 0;
        }
        if (is_moved == false && collision_time >= duration)
        {
            is_moved = true;
            StartCoroutine(Moved());
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (is_moved == false)
        {
            collision_time = 0;
        }
    }

    IEnumerator Moved()
    {
        Vector3 initial_position = transform.position;
        Vector3 final_position = initial_position + offset;

        float initial_time = Time.time;
        float progress = (Time.time - initial_time) / duration;

        while (progress < 1.0f)
        {
            progress = (Time.time - initial_time) / duration;
            Vector3 new_position = Vector3.Lerp(initial_position, final_position, progress);
            transform.position = new_position;

            yield return null;
        }

        transform.position = final_position;
    }
}
