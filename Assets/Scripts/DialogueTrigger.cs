using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    public bool active = true;
   
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            DialogueManager.instance.StartDialogue(dialogue);
            GameObject.Destroy(gameObject);
        }

    }

    public void TriggerDialogue()
    {

        DialogueManager.instance.StartDialogue(dialogue);

    }
}