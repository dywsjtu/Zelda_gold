using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    void Awake()
    {
        offset = transform.position - player.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.GetComponent<Transform>().position + offset;
    }
}
