using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAttack : MonoBehaviour
{
    public GameObject fire;
    public Vector3[] targets;
    public Vector3 original;
    public float duration = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Attack()
    {
        while (true)
        {
            fire.GetComponent<SpriteRenderer>().sortingOrder = 1;

            Vector3 final_position = targets[Random.Range(0, targets.Length)];

            float initial_time = Time.time;
            float progress = (Time.time - initial_time) / duration;
            while (progress < 1.0f)
            {
                progress = (Time.time - initial_time) / duration;
                Vector3 new_position = Vector3.Lerp(original, final_position, progress);
                fire.transform.position = new_position;
                yield return null;
            }
            fire.transform.position = final_position;
            fire.GetComponent<SpriteRenderer>().sortingOrder = -1;
            fire.transform.position = original;
            yield return new WaitForSeconds(Random.Range(2.0f, 3.0f));
        }
    }
}
