using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMovement : MonoBehaviour
{
    public Sprite black;
    public Sprite demon;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Move()
    {
        while (true)
        {
            this.GetComponent<SpriteRenderer>().sprite = black;
            this.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g, this.GetComponent<SpriteRenderer>().color.b, 0);
            Vector3 next_position = new Vector3(Random.Range(81.5f, 93.5f), Random.Range(68.0f, 73.0f), 0);
            float duration = Random.Range(1.0f, 4.0f);
            float initial_time = Time.time;
            float progress = (Time.time - initial_time) / duration;
            while (progress < 1.0f)
            {
                progress = (Time.time - initial_time) / duration;
                yield return null;
            }
            transform.position = next_position;
            this.GetComponent<SpriteRenderer>().sprite = demon;
            this.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g, this.GetComponent<SpriteRenderer>().color.b, 255);
            duration = Random.Range(0.5f, 1.5f);
            initial_time = Time.time;
            progress = (Time.time - initial_time) / duration;
            while (progress < 1.0f)
            {
                progress = (Time.time - initial_time) / duration;
                yield return null;
            }
            yield return null;
        }
    }
}
