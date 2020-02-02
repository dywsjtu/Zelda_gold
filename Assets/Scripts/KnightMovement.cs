using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    public Vector3[] targets;
    public GameObject trigger;
    public int state = 0;
    public float duration = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetComponent<ChessTrigger>().wizard_chess == true && this.tag != "chess")
        {
            this.tag = "chess";
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (trigger.GetComponent<ChessTrigger>().wizard_chess == true)
            {
                Vector3 initial_position = transform.position;
                Vector3 final_position = targets[state];
                float initial_time = Time.time;
                float progress = (Time.time - initial_time) / duration;
                while (progress < 1.0f)
                {
                    progress = (Time.time - initial_time) / duration;
                    Vector3 new_position = Vector3.Lerp(initial_position, final_position, progress);
                    transform.position = new_position;
                    yield return null;
                }
                transform.position = final_position;
                progress = 0.5f;
                while (progress > 0)
                {
                    progress -= Time.deltaTime;
                }
                state = (state + 1) % targets.Length;
            }
            yield return null;
        }
    }
}
