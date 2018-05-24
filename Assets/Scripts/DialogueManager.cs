using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;
    private GameObject player; 
	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("e"))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        player.GetComponent<PlayerControl>().enabled = false;
        player.GetComponent<PlayerGun>().enabled = false;
        player.GetComponent<DashScript>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
        player.GetComponent<Animator>().enabled = false;
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();

    }

    public void DisplayNextSentence ()
    {
        Debug.Log("Dsisplay sentence");
        if (sentences.Count == 0)
        {
            EndDialogue();
            player.GetComponent<PlayerControl>().enabled = true;
            player.GetComponent<PlayerGun>().enabled = true;
            player.GetComponent<DashScript>().enabled = true;
            player.GetComponent<Animator>().enabled = true;
            
            return;
            
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
	
}
