using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy_type;

    public GameObject player;

    public int number = 0;

    List<Vector3> generatePosition = new List<Vector3>
    {
        new Vector3(11, -1, 0), new Vector3(4, -1, 0), new Vector3(4, 11, 0), new Vector3(11, 11, 0)
    };
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(GenerateWallMaster());
        }
    }

    IEnumerator GenerateWallMaster()
    {
        while (InRoom(player.transform.position))
        {
            if (Schedule(player.transform.position - transform.position))
            {
                yield return new WaitForSeconds(3f);
            }
            else {
                yield return 0;
            }
        }
    }

    bool InRoom(Vector3 position)
    {
        Vector3 vec = position - transform.position;
        if (vec.x > 0 && vec.y > 0 && vec.x < 15 && vec.y < 10)
        {
            return true;
        }
        return false;
    }

    bool Schedule(Vector3 position)
    {
        bool down = position.y < 5f;
        bool left = position.x < 7.5f;
        Vector3 initial_dir = Vector3.zero;
        Vector3 initial_pos = Vector3.zero;
        Vector3 move_dir = Vector3.zero;
        if (position.x < 4f && !(position.y < 5f))
        {
            initial_dir = Vector3.right;
            move_dir = Vector3.up;
            initial_pos = new Vector3(-1f, position.y-3, 0f);
        }
        else if (position.x < 4f && position.y < 5f) {
            initial_dir = Vector3.right;
            move_dir = Vector3.down;
            initial_pos = new Vector3(-1f, position.y+3, 0f);
        }
        else if (position.x > 12f && !(position.y < 5f))
        {
            initial_dir = Vector3.left;
            move_dir = Vector3.up;
            initial_pos = new Vector3(16f, position.y-3, 0f);
        }
        else if (position.x > 12f && position.y < 5f)
        {
            initial_dir = Vector3.left;
            move_dir = Vector3.down;
            initial_pos = new Vector3(16f, position.y+3, 0f);

        }
        else if (position.y < 3 && !(position.x < 7.5f))
        {
            initial_dir = Vector3.up;
            move_dir = Vector3.right;
            initial_pos = new Vector3(position.x-3, -1f, 0f);
        }
        else if (position.y < 3 && position.x < 7.5f)
        {
            initial_dir = Vector3.up;
            move_dir = Vector3.left;
            initial_pos = new Vector3(position.x+3, -1f, 0f);
        }
        else if (position.y > 6 && !(position.x < 7.5f))
        {
            initial_dir = Vector3.down;
            move_dir = Vector3.right;
            initial_pos = new Vector3(position.x-3, 11f, 0f);
        }
        else if (position.y > 6 && position.x < 7.5f)
        {
            initial_dir = Vector3.down;
            move_dir = Vector3.left;
            initial_pos = new Vector3(position.x+3, 11f, 0f);
        }

        if (initial_dir == Vector3.zero) return false;
        GameObject sp = Instantiate(enemy_type, transform.position + initial_pos, Quaternion.identity, transform);
        Debug.Log(position);
        sp.GetComponent<WallmasterMovement>().initialDirection = initial_dir;
        sp.GetComponent<WallmasterMovement>().moveDirection = move_dir;
        return true;
    }
}
