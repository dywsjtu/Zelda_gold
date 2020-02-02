using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public float duration = 2.5f;
    public GameObject player;

    RoomTransition rm;
    ArrowKeyMovement player_control;

    // Start is called before the first frame update
    void Start()
    {
        rm = Camera.main.GetComponent<RoomTransition>();
        player_control = player.GetComponent<ArrowKeyMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 offset;
            if (this.CompareTag("lr"))
            {
                if (other.bounds.center.x - transform.position.x < 0)
                {
                    offset = new Vector3(16f * 1, 11f * 0, 0);
                }
                else
                {
                    offset = new Vector3(16f * -1, 11f * 0, 0);
                }
            }
            else
            {
                if (other.bounds.center.y - transform.position.y < 0)
                {
                    offset = new Vector3(16f * 0, 11f * 1, 0);
                }
                else
                {
                    offset = new Vector3(16f * 0, 11f * -1, 0);
                }
            }
            StartCoroutine(Transition(offset));
        }
    }

    IEnumerator Transition(Vector3 offset)
    {
        player_control.Disable();

        Vector3 initial_position = rm.transform.position;
        Vector3 final_position = initial_position + offset;

        float initial_time = Time.time;
        float progress = (Time.time - initial_time) / duration;

        while (progress < 1.0f)
        {
            progress = (Time.time - initial_time) / duration;
            Vector3 new_position = Vector3.Lerp(initial_position, final_position, progress);
            rm.transform.position = new_position;

            yield return null;
        }

        rm.transform.position = final_position;

        if (offset.x > 0)
        {
            offset = new Vector3(1.5f, 0, 0);
        }
        if (offset.x < 0)
        {
            offset = new Vector3(-1.5f, 0, 0);
        }
        if (offset.y > 0)
        {
            offset = new Vector3(0, 1.5f, 0);
        }
        if (offset.y < 0)
        {
            offset = new Vector3(0, -1.5f, 0);
        }
        player.GetComponent<Rigidbody>().MovePosition(transform.position);
        player.GetComponent<Rigidbody>().MovePosition(transform.position + offset);

        player_control.Enable();
    }

    // IEnumerator MoveObjectOverTime(Transform target, Vector3 initial_pos, Vector3 dest_pos, float duration_sec)
    // {
    //     float initial_time = Time.time;
    //     float progress = (Time.time - initial_time) / duration_sec;

    //     while (progress < 1.0f)
    //     {
    //         progress = (Time.time - initial_time) / duration_sec;
    //         Vector3 new_position = Vector3.Lerp(initial_pos, dest_pos, progress);
    //         target.position = new_position;

    //         yield return null;
    //     }

    //     target.position = dest_pos;
    // }

    // IEnumerator WaitForPlayerInputToTransition()
    // {
    //     Vector3 initial_position = rm.transform.position;
    //     Vector3 final_position = new Vector3(39.5f, 18, -10);

    //     yield return StartCoroutine(
    //         MoveObjectOverTime(rm.transform, initial_position, final_position, 2.5f)
    //     );
    // }
}
