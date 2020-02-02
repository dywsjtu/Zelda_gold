using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string[] dialogue_text;
    public float duration = 0.15f;
    public GameObject player;
    public AudioClip dialogue_sound_clip;

    Text text_component;
    ArrowKeyMovement player_control;

    // Start is called before the first frame update
    void Start()
    {
        text_component = GetComponent<Text>();
        text_component.text = "";
        dialogue_text[0] = dialogue_text[0].Replace("\\n", "\n");
        player_control = player.GetComponent<ArrowKeyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(Display(dialogue_text[0]));
        }
    }

    public IEnumerator Display(string dialogue)
    {
        int length = dialogue.Length;
        int current = 0;
        text_component.text = "";
        while (current < length)
        {
            AudioSource.PlayClipAtPoint(dialogue_sound_clip, Camera.main.transform.position);
            text_component.text += dialogue[current];
            current++;
            if (current < length)
            {
                yield return new WaitForSeconds(duration);
            }
            else
            {
                break;
            }
        }
        player_control.Enable();
    }

    public void ClearText()
    {
        text_component.text = "";
    }
}
