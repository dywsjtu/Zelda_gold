using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCDisplayer : MonoBehaviour
{
    public Inventory inventory;
    public Sprite boomerange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inventory != null && inventory.boomerange == true)
        {
            gameObject.GetComponent<Image>().sprite = boomerange;
        }
    }
}
