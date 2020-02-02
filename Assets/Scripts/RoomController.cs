using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RoomController : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject key;
    public int number;
    public bool empty = false;
    // Start is called before the first frame update

    private bool IsEmpty(GameObject[] array)
    {
        return Array.TrueForAll(array, x => x == null);
    }

    void Start()
    {
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEmpty(enemies) || enemies == null)
        {
            empty = true;
            key.SetActive(true);
        }
    }
}
