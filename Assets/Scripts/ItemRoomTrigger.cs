using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRoomTrigger : MonoBehaviour
{
    public GameObject player;

    RoomTransition rm;
    ArrowKeyMovement player_control;
    // Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rm = Camera.main.GetComponent<RoomTransition>();
        player_control = player.GetComponent<ArrowKeyMovement>();
        // animator = player.GetComponent<Animator>();
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
            if (other.bounds.center.x - transform.position.x < 0)
            {
                offset = new Vector3(16f * 0, 11f * 1, 0);
            }
            else
            {
                offset = new Vector3(16f * 0, 11f * -1, 0);
            }
            StartCoroutine(Transition(offset));
        }
    }

    IEnumerator Transition(Vector3 offset)
    {
        player_control.Disable();

        Vector3 initial_position = rm.transform.position;
        Vector3 final_position = initial_position + offset;

        // for (int i = 0; i < 10; i++)
        // {
        //     yield return null;
        // }

        rm.transform.position = final_position;

        if (offset.y > 0)
        {
            player.GetComponent<Rigidbody>().MovePosition(new Vector3(19, 76, 0));
            player.GetComponent<Rigidbody>().MovePosition(new Vector3(19, 75, 0));
            // animator.SetFloat("horizontal_input", 0);
            // animator.SetFloat("vertical_input", -1f);
            // for (int i = 0; i < 10; i++)
            // {
            //     yield return null;
            // }
        }
        else
        {
            player.GetComponent<Rigidbody>().MovePosition(new Vector3(22, 59, 0));
        }

        for (int i = 0; i < 10; i++)
        {
            yield return null;
        }

        player_control.Enable();
    }
}
