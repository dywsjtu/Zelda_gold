using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Drop()
    {
        int prob = Random.Range(0, 10);
        if (prob >= 7) {
            Instantiate(items[Random.Range(0, 3)], transform.position, Quaternion.identity);
        }
    }
}
