using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public AudioClip rupee_collection_sound_clip;
    public AudioClip key_collection_sound_clip;
    public AudioClip bomb_collection_sound_clip;
    public AudioClip bow_collection_sound_clip;

    Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        if (inventory == null)
        {
            Debug.LogWarning("WARNING: GameObject with a collector has no inventory to store things in!");
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject object_collided_with = coll.gameObject;

        if (object_collided_with.tag == "rupee")
        {
            if (inventory != null)
            {
                inventory.AddRupees(1);
            }
            Destroy(object_collided_with);

            AudioSource.PlayClipAtPoint(rupee_collection_sound_clip, Camera.main.transform.position);
        }

        if (object_collided_with.tag == "key")
        {
            if (inventory != null)
            {
                inventory.AddKeys(1);
            }
            Destroy(object_collided_with);

            AudioSource.PlayClipAtPoint(key_collection_sound_clip, Camera.main.transform.position);
        }

        if (object_collided_with.tag == "bomb")
        {
            if (inventory != null)
            {
                inventory.AddBombs(1);
            }
            Destroy(object_collided_with);

            AudioSource.PlayClipAtPoint(bomb_collection_sound_clip, Camera.main.transform.position);
        }

        if (object_collided_with.tag == "bow")
        {
            if (inventory != null)
            {
                inventory.WeaponBow();
            }
            Destroy(object_collided_with);

            AudioSource.PlayClipAtPoint(bow_collection_sound_clip, Camera.main.transform.position);
        }

        if (object_collided_with.tag == "boomerangeicon")
        {
            if (inventory != null)
            {
                inventory.WeaponBoomerange();
            }
            Destroy(object_collided_with);

            AudioSource.PlayClipAtPoint(bow_collection_sound_clip, Camera.main.transform.position);
        }
    }
}
