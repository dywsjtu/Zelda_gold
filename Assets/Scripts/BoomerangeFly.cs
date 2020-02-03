using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangeFly : MonoBehaviour
{
    public GameObject boomerange;
    private bool fly = false;
    GoriyaMovement movement;
    private Vector3 offset;
    Vector3 threhold;
    Rigidbody rb;

    void Awake()
    {
        rb = boomerange.GetComponent<Rigidbody>();
        movement = GetComponent<GoriyaMovement>();
        offset = boomerange.GetComponent<Transform>().position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(movement.GetBack());
        // if (movement.GetBack())
        // {
        //     // Debug.Log("back");
        //     // Vector3 direction = Vector3.Normalize(-boomerange.GetComponent<Transform>().position + transform.position);
        //     // rb.velocity = direction * 5;
        //     boomerange.GetComponent<Transform>().position += movement.GetDirection() / 5f;
        // }
        // else
        // {
        if (fly == false)
        {
            boomerange.GetComponent<Transform>().position = transform.position + offset;
        }
        else
        {
            StartCoroutine(Fly());
            //boomerange.GetComponent<Transform>().position += movement.GetDirection() / 5f;
        }
        // }
    }

    IEnumerator Fly()
    {
        boomerange.GetComponent<SpriteRenderer>().sortingOrder = 2;
        rb.velocity = movement.GetDirection() * 5;
        int t = 25;
        while (t > 0)
        {
            t--;
            yield return 0;
        }
        // Debug.Log("40_1");
        rb.velocity = Vector3.zero;
        t = 10;
        while (t > 0)
        {
            t--;
            yield return 0;
        }
        // Debug.Log("10_1");
        Vector3 initial_position = boomerange.GetComponent<Transform>().position;
        Vector3 final_position = movement.transform.position;

        float duration = 1f;
        float initial_time = Time.time;
        float progress = (Time.time - initial_time) / duration;

        while (progress < 1.0f)
        {
            progress = (Time.time - initial_time) / duration;
            Vector3 new_position = Vector3.Lerp(initial_position, final_position, progress);
            boomerange.GetComponent<Transform>().position = new_position;

            yield return null;
        }

        boomerange.GetComponent<Transform>().position = final_position;
        // t = 10;
        // while (t > 0)
        // {
        //     t--;
        //     yield return 0;
        // }
        boomerange.GetComponent<SpriteRenderer>().sortingOrder = -1;
        fly = false;
        movement.SetAttack(false);
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (fly == true && other.tag != "heart" && other.tag != "key" && other.tag != "rupee")
    //     {
    //         gameObject.layer = 12;
    //         gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
    //         transform.position = boomerange.GetComponent<Transform>().position + offset;
    //         fly = false;
    //         //boomerange.GetComponent<Weapon>().is_flying = false;
    //     }
    //     // Debug.Log("111");
    //     // if (other.gameObject.tag == "Goriya") {
    //     //     Debug.Log("222");
    //     //     movement.SetBack(false);
    //     //     movement.SetAttack(false);
    //     //     fly = false;
    //     // }
    //
    // }

    public void SetFly(bool value)
    {
        fly = value;
    }
}
