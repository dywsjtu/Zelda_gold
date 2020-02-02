using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;

    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tile_WALL")
        {
            Destroy(gameObject);
        }
    }

}
