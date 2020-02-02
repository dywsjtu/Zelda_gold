using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldManDoorTrigger : MonoBehaviour
{
    public float duration = 2.5f;
    public GameObject player;
    public GameObject dialogue;
    public GameObject block;

    private bool enter = true;

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
            if (other.bounds.center.x - transform.position.x < 0)
            {
                offset = new Vector3(16f * 1, 11f * 0, 0);
                enter = false;
            }
            else
            {
                offset = new Vector3(16f * -1, 11f * 0, 0);
                enter = true;
            }
            StartCoroutine(Transition(offset, enter));
        }
    }

    IEnumerator Transition(Vector3 offset, bool enter)
    {
        player_control.Disable();

        if (enter == false)
        {
            dialogue.GetComponent<Dialogue>().ClearText();
            block.transform.position = new Vector3(block.transform.position.x - 1, block.transform.position.y, block.transform.position.z);
            block.GetComponent<Movable>().is_moved = false;
        }

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
            offset = new Vector3(2.5f, 0, 0);
        }
        if (offset.x < 0)
        {
            offset = new Vector3(-1.5f, 0, 0);
        }
        player.GetComponent<Rigidbody>().MovePosition(transform.position);
        player.GetComponent<Rigidbody>().MovePosition(transform.position + offset);

        if (enter)
        {
            StartCoroutine(dialogue.GetComponent<Dialogue>().Display(dialogue.GetComponent<Dialogue>().dialogue_text[0]));
        }
        else
        {
            block.GetComponent<UnlockSpecialDoor>().target.GetComponent<SpriteRenderer>().sprite = block.GetComponent<UnlockSpecialDoor>().locked;
            block.GetComponent<UnlockSpecialDoor>().target.layer = 0;
            player_control.Enable();
        }
    }
}
