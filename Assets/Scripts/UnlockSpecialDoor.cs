using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSpecialDoor : MonoBehaviour
{
    public GameObject target;
    public Sprite unlocked;
    public Sprite locked;

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
        if (other.gameObject.tag == "special_door")
        {
            target.GetComponent<SpriteRenderer>().sprite = unlocked;
            target.layer = 9;
        }
    }
}
