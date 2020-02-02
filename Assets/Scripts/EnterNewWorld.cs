using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterNewWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Camera.main.GetComponent<RoomTransition>().transform.position = new Vector3(87.5f, 62.0f, -10.0f);
            transform.position = new Vector3(87.0f, 57.0f, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "triangle")
        {
            Camera.main.GetComponent<RoomTransition>().transform.position = new Vector3(87.5f, 62.0f, -10.0f);
            transform.position = new Vector3(87.0f, 57.0f, transform.position.z);
        }
        if (other.tag == "next")
        {
            Camera.main.GetComponent<RoomTransition>().transform.position = new Vector3(87.5f, 73.0f, -10.0f);
            transform.position = new Vector3(87.5f, 67.0f, transform.position.z);
        }
        if (other.tag == "head")
        {
            Camera.main.GetComponent<RoomTransition>().transform.position = new Vector3(87.5f, 84.0f, -10.0f);
            transform.position = new Vector3(87.5f, 78.0f, transform.position.z);
        }
        if (other.tag == "begin_again")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
