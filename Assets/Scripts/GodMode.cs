using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    static public bool god_mode;

    private int num_rupees;
    private int num_keys;
    private int num_bombs;

    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        god_mode = false;
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            god_mode = !god_mode;

            if (god_mode)
            {
                num_rupees = inventory.GetRupees();
                num_keys = inventory.GetKeys();
                num_bombs = inventory.GetBombs();
                inventory.SetRupees(99);
                inventory.SetKeys(99);
                inventory.SetBombs(99);
                transform.gameObject.layer = 11;
            }
            else
            {
                inventory.SetRupees(num_rupees);
                inventory.SetKeys(num_keys);
                inventory.SetBombs(num_bombs);
                transform.gameObject.layer = 8;
            }
        }
    }

    public bool GetMode()
    {
        return god_mode;
    }

    public void ChangeMode()
    {
        god_mode = !god_mode;
        if (transform.gameObject.layer == 11)
        {
            transform.gameObject.layer = 8;
        }
        else
        {
            transform.gameObject.layer = 11;
        }
    }
}
