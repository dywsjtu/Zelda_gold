using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFly : MonoBehaviour
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
        if (fly == true && other.tag != "heart" && other.tag != "key" && other.tag != "rupee" && other.tag != "Gel" && other.tag != "Stalfos" && other.tag != "Keese" && other.tag != "BladeTrap" && other.tag != "obstacle")
        {
            gameObject.layer = 17;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
            transform.position = player.GetComponent<Transform>().position + offset;
            fly = false;
            player.GetComponent<Weapon>().is_flying = false;
        }
    }

    public void SetFly()
    {
        fly = true;
    }
}
