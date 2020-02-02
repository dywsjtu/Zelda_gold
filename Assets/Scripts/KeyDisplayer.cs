using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDisplayer : MonoBehaviour
{
    public Inventory inventory;

    Text text_component;

    // Start is called before the first frame update
    void Start()
    {
        text_component = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory != null && text_component != null)
        {
            text_component.text = "Key: " + inventory.GetKeys().ToString();
        }
    }
}
