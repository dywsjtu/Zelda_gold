using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimator : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }

        Vector2 dir = GetComponent<ArrowKeyMovement>().GetInput();
        if (dir.x == 0 && dir.y == 0)
        {
            animator.SetBool("idle", true);
        }
        else if (animator.GetBool("attack"))
        {
            animator.SetBool("idle", true);
        }
        else
        {
            animator.SetBool("idle", false);
        }

        animator.SetFloat("horizontal_input", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("vertical_input", Input.GetAxisRaw("Vertical"));

        // if (Input.GetAxisRaw("Horizontal") == 0.0f && Input.GetAxisRaw("Vertical") == 0.0f)
        // {
        //     animator.speed = 0.0f;
        // }
        // else
        // {
        //     animator.speed = 1.0f;
        // }
    }

    void Attack()
    {
        animator.SetTrigger("press");
        if (GetComponent<Weapon>().GetWeapon() != null)
        {
            StartCoroutine(Wait(GetComponent<Weapon>().GetWeapon()));
        }
    }

    IEnumerator Wait(GameObject weapon)
    {
        animator.SetBool("attack", true);
        weapon.layer = 13;
        weapon.GetComponent<SpriteRenderer>().sortingOrder = 1;
        int duration = 5;
        while (duration > 0)
        {
            duration -= 1;
            yield return null;
        }
        weapon.GetComponent<SpriteRenderer>().sortingOrder = -1;
        weapon.layer = 12;
        animator.SetBool("attack", false);
    }
}
