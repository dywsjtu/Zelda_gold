using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessTrigger : MonoBehaviour
{
    public bool wizard_chess = false;
    public GameObject triangle;

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
        // Debug.Log("s");
        if (other.tag == "Player")
        {
            // Debug.Log("s");
            wizard_chess = true;
            triangle.gameObject.layer = 0;
            triangle.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
}
