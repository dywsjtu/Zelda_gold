using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public AudioClip life_collection_sound_clip;
    public AudioClip life_lose_sound_clip;
    public AudioClip link_die_sound_clip;
    public AudioClip link_low_life_sound_clip;

    float life = 3f;
    float hell_time = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            AudioSource.PlayClipAtPoint(link_die_sound_clip, Camera.main.transform.position);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (life <= 1 && life > 0)
        {
            AudioSource.PlayClipAtPoint(link_low_life_sound_clip, Camera.main.transform.position);
        }
    }

    void AddLife(float num_life)
    {
        if (life < 3f)
        {
            life += num_life;
        }
    }

    public float GetHealth()
    {
        return life;
    }

    void LoseLife(float num_life)
    {
        if (life - num_life < 0)
        {
            life = 0;
        }
        else
        {
            life -= num_life;
        }
    }

    void OnCollisionStay(Collision other)
    {
        GameObject object_collided_with = other.gameObject;

        if (object_collided_with.tag == "Stalfos" || object_collided_with.tag == "Keese" || object_collided_with.tag == "Gel" || object_collided_with.tag == "Aquamentus" || object_collided_with.tag == "goriya" || object_collided_with.tag == "boomerange" || object_collided_with.tag == "BladeTrap" || object_collided_with.tag == "chess")
        {
            AudioSource.PlayClipAtPoint(life_lose_sound_clip, Camera.main.transform.position);
            this.LoseLife(0.5f);
            // GetComponent<GodMode>().ChangeMode();
            Vector3 force = -other.transform.position + transform.position;
            if (Mathf.Abs(force.x) >= Mathf.Abs(force.y))
            {
                force.y = 0;
                force.x = force.x / Mathf.Abs(force.x);
            }
            else
            {
                force.x = 0;
                force.y = force.y / Mathf.Abs(force.y);
            }
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(force * 1000);
            StartCoroutine(Invincible());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bat")
        {
            this.LoseLife(0.5f);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject object_collided_with = other.gameObject;

        if (object_collided_with.tag == "heart")
        {
            this.AddLife(0.5f);
            Destroy(object_collided_with);

            AudioSource.PlayClipAtPoint(life_collection_sound_clip, Camera.main.transform.position);
        }
        if (object_collided_with.tag == "fire")
        {
            this.LoseLife(0.5f);
            // Destroy(object_collided_with);

            // AudioSource.PlayClipAtPoint(life_collection_sound_clip, Camera.main.transform.position);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "hell_floor")
        {
            hell_time = 0;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "hell_floor")
        {
            hell_time += Time.deltaTime;
            if (hell_time >= 1.5f)
            {
                hell_time -= 1.5f;
                this.LoseLife(0.5f);
            }
        }
    }

    IEnumerator Invincible()
    {
        GetComponent<GodMode>().ChangeMode();
        int duration = 10;
        while (duration > 0)
        {
            duration -= 1;
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            yield return null;
        }
        GetComponent<GodMode>().ChangeMode();
    }
}
