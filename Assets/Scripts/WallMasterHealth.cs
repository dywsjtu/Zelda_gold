using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMasterHealth : MonoBehaviour
{
    public AudioClip enemy_hit_sound_clip;
    public AudioClip enemy_die_sound_clip;

    private int life = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Debug.Log("Dead");
            AudioSource.PlayClipAtPoint(enemy_die_sound_clip, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sword")
        {
            Debug.Log("Attacked by Sword");
            AudioSource.PlayClipAtPoint(enemy_hit_sound_clip, Camera.main.transform.position);
            life -= 1;
        }
        if (other.gameObject.tag == "arrow")
        {
            AudioSource.PlayClipAtPoint(enemy_hit_sound_clip, Camera.main.transform.position);
            life -= 1;
        }
        if (other.gameObject.tag == "linkboomerange")
        {
            AudioSource.PlayClipAtPoint(enemy_hit_sound_clip, Camera.main.transform.position);
            life -= 1;
        }
    }
}
