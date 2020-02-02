using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHead : MonoBehaviour
{
    public GameObject bat1;
    public GameObject bat2;
    public GameObject bat3;
    public bool is_shown = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (is_shown == false && bat1 == null && bat2 == null && bat3 == null)
        {
            gameObject.layer = 0;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
}
