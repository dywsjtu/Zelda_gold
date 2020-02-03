using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoriyaHealth : MonoBehaviour
{
    public AudioClip enemy_hit_sound_clip;
    public AudioClip enemy_die_sound_clip;

    private int life = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            AudioSource.PlayClipAtPoint(enemy_die_sound_clip, Camera.main.transform.position);
            GetComponent<DropItem>().Drop();
            Destroy(GetComponent<BoomerangeFly>().boomerange);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sword"))
        {
            AudioSource.PlayClipAtPoint(enemy_hit_sound_clip, Camera.main.transform.position);
            life -= 1;
        }
        if (other.CompareTag("arrow"))
        {
            AudioSource.PlayClipAtPoint(enemy_hit_sound_clip, Camera.main.transform.position);
            life -= 1;
        }
        if (other.CompareTag("linkboomerange"))
        {
            StartCoroutine(Stun());
            AudioSource.PlayClipAtPoint(enemy_hit_sound_clip, Camera.main.transform.position);
            life -= 1;
        }
        if (other.CompareTag("bomb"))
        {
            AudioSource.PlayClipAtPoint(enemy_hit_sound_clip, Camera.main.transform.position);
            life -= 1;
        }
    }

    IEnumerator Stun()
    {
        GetComponent<GoriyaMovement>().stun = true;

        float t = Time.time;
        float progress = (Time.time - t) / 1f;
        while (progress < 1f)
        {
            progress = (Time.time - t) / 1f;
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            yield return null;
        }
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<GoriyaMovement>().stun = false;
    }
}
