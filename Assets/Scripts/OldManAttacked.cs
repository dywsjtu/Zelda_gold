using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManAttacked : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        StartCoroutine(Invincible());
    }

    IEnumerator Invincible()
    {
        int duration = 10;
        while (duration > 0)
        {
            duration -= 1;
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            yield return null;
        }
    }
}
