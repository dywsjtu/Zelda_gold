using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int rupee_count = 0;
    int key_count = 0;
    int bomb_count = 0;
    public bool bow = false;
    public bool bomb = false;
    public bool boomerange = false;

    public void AddRupees(int num_rupees)
    {
        if (rupee_count + num_rupees <= 99)
        {
            rupee_count += num_rupees;
        }
        else
        {
            rupee_count = 99;
        }
    }

    public int GetRupees()
    {
        return rupee_count;
    }

    public void UseRupees(int num_rupees)
    {
        if (GetComponent<GodMode>().GetMode())
        {
            return;
        }
        if (rupee_count - num_rupees >= 0)
        {
            rupee_count -= num_rupees;
        }
        else
        {
            rupee_count = 0;
        }
    }

    public void SetRupees(int num_rupees)
    {
        rupee_count = num_rupees;
    }

    public void AddKeys(int num_keys)
    {
        if (key_count + num_keys <= 99)
        {
            key_count += num_keys;
        }
        else
        {
            key_count = 99;
        }
    }

    public int GetKeys()
    {
        return key_count;
    }

    public void UseKeys(int num_keys)
    {
        if (GetComponent<GodMode>().GetMode())
        {
            return;
        }
        if (key_count - num_keys >= 0)
        {
            key_count -= num_keys;
        }
        else
        {
            key_count = 0;
        }
    }

    public void SetKeys(int num_keys)
    {
        key_count = num_keys;
    }

    public void AddBombs(int num_Bombs)
    {
        if (bomb_count + num_Bombs <= 99)
        {
            bomb_count += num_Bombs;
        }
        else
        {
            bomb_count = 99;
        }
    }

    public int GetBombs()
    {
        return bomb_count;
    }

    public void UseBombs(int num_Bombs)
    {
        if (GetComponent<GodMode>().GetMode())
        {
            return;
        }
        if (bomb_count - num_Bombs >= 0)
        {
            bomb_count -= num_Bombs;
        }
        else
        {
            bomb_count = 0;
        }
    }

    public void SetBombs(int num_Bombs)
    {
        bomb_count = num_Bombs;
    }

    public void WeaponBow()
    {
        bow = true;
        GetComponent<Weapon>().weapon_got[1] = true;
    }

    public void WeaponBomb()
    {
        bomb = true;
        GetComponent<Weapon>().weapon_got[3] = true;
    }

    public void WeaponBoomerange()
    {
        boomerange = true;
        GetComponent<Weapon>().weapon_got[2] = true;
    }
}
