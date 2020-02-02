using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkBoomerangeFly : MonoBehaviour
{
    public GameObject player;
    private bool fly = false;

    private Vector3 offset;

    void Awake()
    {
        offset = transform.position - player.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (fly == false)
        {
            transform.position = player.GetComponent<Transform>().position + offset;
        }
        else
        {
            transform.position += offset / 5f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (fly == true && other.tag != "heart" && other.tag != "key" && other.tag != "rupee" && other.tag != "obstacle")
        {
            // gameObject.layer = 17;
            // gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
            // transform.position = player.GetComponent<Transform>().position + offset;
            // fly = false;
            // player.GetComponent<Weapon>().is_flying = false;
            StartCoroutine(GetBack());
        }
    }

    IEnumerator GetBack()
    {
        Vector3 initial_position = transform.position;
        Vector3 final_position = player.transform.position;

        float initial_time = Time.time;
        float progress = (Time.time - initial_time) / 1;

        while (progress < 1.0f)
        {
            progress = (Time.time - initial_time) / 1;
            Vector3 new_position = Vector3.Lerp(initial_position, final_position, progress);
            transform.position = new_position;

            yield return null;
        }

        transform.position = final_position;

        gameObject.layer = 24;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
        fly = false;
        player.GetComponent<Weapon>().is_flying = false;
        player.GetComponent<ArrowKeyMovement>().Enable();
    }

    public void SetFly()
    {
        fly = true;
    }
}
