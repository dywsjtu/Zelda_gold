using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDDisplayer : MonoBehaviour
{
    public Inventory inventory;
    public Sprite bomb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inventory != null && inventory.bomb == true)
        {
            gameObject.GetComponent<Image>().sprite = bomb;
        }
    }
}
