using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public Sprite unlocked_left;
    public Sprite unlocked_right;
    public Sprite unlocked_up_left;
    public Sprite unlocked_up_right;
    public Sprite locked_left;
    public Sprite locked_right;
    public Sprite locked_up_left;
    public Sprite locked_up_right;
    public AudioClip unlock_sound_clip;
    // public Sprite special_lock;

    bool lefthalf = false;
    bool righthalf = false;
    SpriteRenderer[] sprites = { null, null };

    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
        if (inventory == null)
        {
            Debug.LogWarning("WARNING: GameObject with a collector has no inventory to store things in!");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject locked_door = other.gameObject;
        SpriteRenderer spriteRender = locked_door.GetComponent<SpriteRenderer>();
        if (inventory != null && inventory.GetKeys() > 0)
        {
            if (locked_door.tag == "locked_left")
            {
                AudioSource.PlayClipAtPoint(unlock_sound_clip, Camera.main.transform.position);
                inventory.UseKeys(1);
                spriteRender.sprite = unlocked_left;
                locked_door.layer = 9;
            }
            if (locked_door.tag == "locked_right")
            {
                AudioSource.PlayClipAtPoint(unlock_sound_clip, Camera.main.transform.position);
                inventory.UseKeys(1);
                spriteRender.sprite = unlocked_right;
                locked_door.layer = 9;
            }
            if (locked_door.tag == "locked")
            {
                if (spriteRender.sprite == locked_up_left)
                {
                    lefthalf = true;
                    sprites[0] = spriteRender;
                }
                if (spriteRender.sprite == locked_up_right)
                {
                    righthalf = true;
                    sprites[1] = spriteRender;
                }
                locked_door.layer = 9;
                if (lefthalf && righthalf)
                {
                    AudioSource.PlayClipAtPoint(unlock_sound_clip, Camera.main.transform.position);
                    lefthalf = false;
                    righthalf = false;
                    for (int i = 0; i < 2; i++)
                    {
                        if (sprites[i].sprite == locked_up_left)
                        {
                            sprites[i].sprite = unlocked_up_left;
                        }
                        else
                        {
                            sprites[i].sprite = unlocked_up_right;
                        }
                    }
                    inventory.UseKeys(1);
                }
            }
        }
    }
}
