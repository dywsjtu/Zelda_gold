﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject[] swords;
    public GameObject[] sword_fly;
    public GameObject[] arrows;
    public GameObject[] boomerange;
    public int which_weapon = 0;
    public bool[] weapon_got = { true, false, false, false };
    public Vector3[] direction = { Vector3.up, Vector3.down, Vector3.left, Vector3.right };
    public bool is_flying = false;
    public AudioClip sword_sound_clip;
    public AudioClip sword_fly_sound_clip;
    public AudioClip arrow_sound_clip;
    public AudioClip bomb_explode_clip;
    public AudioClip bomb_drop_clip;
    private GameObject bomb;
    public GameObject bomb_prefab;
    public bool bomb_exist = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (is_flying == false)
        {
            if (Input.GetKeyDown(KeyCode.B) && weapon_got[0] == true)
            {
                which_weapon = 0;
            }
            if (Input.GetKeyDown(KeyCode.N) && weapon_got[1] == true)
            {
                which_weapon = 1;
            }
            if (Input.GetKeyDown(KeyCode.M) && weapon_got[2] == true)
            {
                which_weapon = 2;
            }
            if (Input.GetKeyDown(KeyCode.H) && weapon_got[3] == true)
            {
                which_weapon = 3;
            }
        }
    }

    public GameObject GetWeapon()
    {
        if (which_weapon == 0)
        {
            if (GetComponent<Health>().GetHealth() == 3.0f && is_flying == false)
            {
                is_flying = true;
                sword_fly[GetComponent<ArrowKeyMovement>().dir].layer = 13;
                sword_fly[GetComponent<ArrowKeyMovement>().dir].GetComponent<SpriteRenderer>().sortingOrder = 1;
                sword_fly[GetComponent<ArrowKeyMovement>().dir].GetComponent<SwordFly>().SetFly();
                AudioSource.PlayClipAtPoint(sword_fly_sound_clip, Camera.main.transform.position);
            }
            else
            {
                AudioSource.PlayClipAtPoint(sword_sound_clip, Camera.main.transform.position);
            }
            return swords[GetComponent<ArrowKeyMovement>().dir];
        }
        if (which_weapon == 1)
        {
            if (is_flying == false && GetComponent<Inventory>().GetRupees() > 0)
            {
                is_flying = true;
                GetComponent<Inventory>().UseRupees(1);
                arrows[GetComponent<ArrowKeyMovement>().dir].layer = 18;
                arrows[GetComponent<ArrowKeyMovement>().dir].GetComponent<SpriteRenderer>().sortingOrder = 1;
                arrows[GetComponent<ArrowKeyMovement>().dir].GetComponent<ArrowFly>().SetFly();
            }
        }
        if (which_weapon == 2)
        {
            if (is_flying == false)
            {
                GetComponent<ArrowKeyMovement>().Disable();
                is_flying = true;
                boomerange[GetComponent<ArrowKeyMovement>().dir].layer = 23;
                boomerange[GetComponent<ArrowKeyMovement>().dir].GetComponent<SpriteRenderer>().sortingOrder = 1;
                boomerange[GetComponent<ArrowKeyMovement>().dir].GetComponent<LinkBoomerangeFly>().SetFly();
            }
        }
        if (which_weapon == 3 )
        {
            if (GetComponent<Inventory>().GetBombs() == 0)
            {
                return null;
            }
            if (bomb_exist)
            {
                return null;
            }
            Vector3 player_position = transform.position;
            Vector3 bomb_position = player_position + direction[GetComponent<ArrowKeyMovement>().dir];
            GetComponent<Inventory>().UseBombs(1);
            AudioSource.PlayClipAtPoint(bomb_drop_clip, Camera.main.transform.position);
            Debug.Log("Bomb Initialization");
            bomb = Instantiate(bomb_prefab, bomb_position, Quaternion.identity);
            bomb_exist = true;

            StartCoroutine(Explode());
        }
        return null;
    }

    IEnumerator Explode()
    {
        int t = 50;
        while (t > 0)
        {
            t--;
            yield return 0;
        }
        bomb.GetComponent<CapsuleCollider>().enabled = true;
        bomb.GetComponent<Animator>().SetBool("start", true);
        AudioSource.PlayClipAtPoint(bomb_explode_clip, Camera.main.transform.position);
        t = 30;
        while (t > 0)
        {
            t--;
            yield return 0;
        }
        bomb.GetComponent<CapsuleCollider>().enabled = false;
        bomb.GetComponent<Animator>().SetBool("start", false);
        Destroy(bomb);
        bomb_exist = false;
    }

}
