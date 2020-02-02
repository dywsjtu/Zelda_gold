using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRoomBlockReset : MonoBehaviour
{
    public GameObject block;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        block.transform.position = new Vector3(22, 60, 0);
        block.GetComponent<Movable>().is_moved = false;
    }
}
