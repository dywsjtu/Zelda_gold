using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBDisplayer : MonoBehaviour
{
    public Inventory inventory;
    public Sprite bow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inventory != null && inventory.bow == true)
        {
            gameObject.GetComponent<Image>().sprite = bow;
        }
    }
}
