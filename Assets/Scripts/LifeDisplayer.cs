using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplayer : MonoBehaviour
{
    public Health health;
    public Sprite empty;
    public Sprite half;
    public Sprite full;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    Text text_component;

    // Start is called before the first frame update
    void Start()
    {
        text_component = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health != null && text_component != null)
        {
            text_component.text = "Life: " + health.GetHealth().ToString();
        }
        switch (health.GetHealth())
        {
            case 0.0f:
                life1.GetComponent<Image>().sprite = empty;
                life2.GetComponent<Image>().sprite = empty;
                life3.GetComponent<Image>().sprite = empty;
                break;
            case 0.5f:
                life1.GetComponent<Image>().sprite = half;
                life2.GetComponent<Image>().sprite = empty;
                life3.GetComponent<Image>().sprite = empty;
                break;
            case 1.0f:
                life1.GetComponent<Image>().sprite = full;
                life2.GetComponent<Image>().sprite = empty;
                life3.GetComponent<Image>().sprite = empty;
                break;
            case 1.5f:
                life1.GetComponent<Image>().sprite = full;
                life2.GetComponent<Image>().sprite = half;
                life3.GetComponent<Image>().sprite = empty;
                break;
            case 2.0f:
                life1.GetComponent<Image>().sprite = full;
                life2.GetComponent<Image>().sprite = full;
                life3.GetComponent<Image>().sprite = empty;
                break;
            case 2.5f:
                life1.GetComponent<Image>().sprite = full;
                life2.GetComponent<Image>().sprite = full;
                life3.GetComponent<Image>().sprite = half;
                break;
            case 3.0f:
                life1.GetComponent<Image>().sprite = full;
                life2.GetComponent<Image>().sprite = full;
                life3.GetComponent<Image>().sprite = full;
                break;
            default:
                break;
        }
    }
}
