using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    public bool dialogueOn = false;
    private GameObject dialogueBox;
    private Queue<string> sentences;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        if (!dialogueBox)
        {
            dialogueBox = GameObject.FindGameObjectWithTag("DialogueBox");
            nameText = dialogueBox.transform.GetChild(0).GetComponent<Text>();
            dialogueText = dialogueBox.transform.GetChild(1).GetComponent<Text>();
            animator = dialogueBox.GetComponent<Animator>();

        }
        sentences = new Queue<string>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public static DialogueManager instance;
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            Destroy(gameObject);
        }


        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (dialogueOn)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DisplayNextSentence();
            }
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        if (!dialogueBox)
        {
            dialogueBox = GameObject.FindGameObjectWithTag("DialogueBox");
            nameText = dialogueBox.transform.GetChild(0).GetComponent<Text>();
            dialogueText = dialogueBox.transform.GetChild(1).GetComponent<Text>();
            animator = dialogueBox.GetComponent<Animator>();

        }
        dialogueOn = true;
        animator.SetBool("IsOpen", true);
        player.GetComponent<PlayerControl>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.GetComponent<Animator>().enabled = false;
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        Debug.Log("Dsisplay sentence");
        if (sentences.Count == 0)
        {
            EndDialogue();
            player.GetComponent<PlayerControl>().enabled = true;
            player.GetComponent<Animator>().enabled = true;

            return;

        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
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
        dialogueOn = false;
        animator.SetBool("IsOpen", false);
    }

}
