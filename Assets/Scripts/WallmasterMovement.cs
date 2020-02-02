using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallmasterMovement : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject camera;
    public Vector3 initialDirection;
    public Vector3 moveDirection;
    public float moveSpeed = 1f;
    private float speed;
    private Vector3 direction;
    private string state = "Move";
    private Rigidbody rb;
    private GameObject player = null;
    public Vector3 resetPosition;

    void Start()
    {
        speed = moveSpeed;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MoveSchedule());
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed * direction;
        if (player != null){
            player.transform.position = transform.position;
        }
    }

    IEnumerator MoveSchedule()
    {
        direction = initialDirection;
        yield return new WaitForSeconds(3f/moveSpeed);
        float t = 4.5f/moveSpeed;
        direction = moveDirection;
        while (t > 0)
        {
            if (state == "Move")
            {
                t -= Time.deltaTime;
            }
            // else
            // {
            //     t = 3f / moveSpeed;
            // }
            yield return 0;
        }
        direction = -initialDirection;
        yield return new WaitForSeconds(3f/moveSpeed);
        speed = 0f;
        if (player){
            player.GetComponent<ArrowKeyMovement>().Enable();
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Health>().SetCatch();
            player.transform.position = new Vector3(39.5f, 1, 0);
            player = null;
            camera.transform.position = new Vector3(39.5f, 7f, -10);
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!other.gameObject.GetComponent<Health>().GetCatch())
            {
                player = other.gameObject;
                // player.GetComponent<Health>().SetCatch();
                // player.GetComponent<ArrowKeyMovement>().Disable();

            }
            Debug.Log("wallmaster get player");
        }
    }

}
