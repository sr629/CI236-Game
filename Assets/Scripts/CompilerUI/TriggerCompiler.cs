using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerCompiler : MonoBehaviour
{

    public static bool paused = false;
    public GameObject player;

    private PlayerControl playerScript;
    private DashScript dashScript;
    private PlayerGun shootScript;
    private GameObject screen;
    private Text popUpText;

    public GameObject prefabBlock;
    public GameObject prefabAnswer;
    private bool textOn = false;
    private GameObject codeBlockPanel;
    private GameObject solutionPanel;
    private GameObject currentCompiler;
    private string answerString;
    private Text outputText;
    private void Start()
    {
        codeBlockPanel = GameObject.FindGameObjectWithTag("CodeBlocks");
        solutionPanel = GameObject.FindGameObjectWithTag("SolutionBlocks");
        outputText = GameObject.Find("OutputText").GetComponent<Text>();
        popUpText = transform.GetChild(1).gameObject.GetComponent<Text>();
        popUpText.enabled = false;
        screen = transform.GetChild(0).gameObject;
        screen.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerControl>();
        dashScript = player.GetComponent<DashScript>();
        shootScript = player.GetComponent<PlayerGun>();
    }
    private static TriggerCompiler instance;
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
        if (paused && Input.GetKeyDown(KeyCode.Q))
        {
            ClearCompiler();
            OpenCompiler();
            
        }
    }
    public void OpenCloseText(bool flag)
    {
        popUpText.enabled = flag;
    }
    public void OpenCompiler()
    {   
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerScript = player.GetComponent<PlayerControl>();
            dashScript = player.GetComponent<DashScript>();
            shootScript = player.GetComponent<PlayerGun>();
        }

        if (paused == true)
        {
            popUpText.GetComponent<Text>().enabled = true;
            Resume();
            playerScript.enabled = true;
        }
        else
        {
            popUpText.GetComponent<Text>().enabled = false;
            Pause();
            playerScript.enabled = false;    
        }
    }
    public void ClearCompiler()
    {
        CellScript[] toDelete = GetComponentsInChildren<CellScript>();
        foreach (CellScript item in toDelete)
        {
            Destroy(item.gameObject);
        }
        outputText.text = ">input solution";
    }
    public void SetupCompiler(string[] codeBlocks,string[] answer, GameObject compiler)
    {
        //string[] codeBlocks = compiler.GetComponent<OpenCompilerFromCollider>().codeBlocks;
        currentCompiler = compiler;
        if(currentCompiler.GetComponent<OpenCompilerFromCollider>().solved==true)
        {
            outputText.text = ">puzzle already completed\n>press q to exit";
        }
        answerString = string.Concat(answer);
        int solutionLength = answer.Length;
        int index = 0;
        
        foreach (string codeBlock in codeBlocks)
        {
            if (solutionLength > 0) Instantiate(prefabAnswer, solutionPanel.transform);
            Instantiate(prefabBlock, codeBlockPanel.transform);
            codeBlockPanel.transform.GetChild(index).GetComponentInChildren<Text>().text = codeBlock;
            index++;
            solutionLength--;
        }
        
    }
    public void CheckSolution()
    {
        Text[] inputAnwers = solutionPanel.GetComponentsInChildren<Text>();
        string[] inputStrings = new string[inputAnwers.Length];
        int index = 0;
        foreach (Text item in inputAnwers)
        {
            inputStrings[index] = item.text;
            index++;
        }

        index = 0;
        string output = string.Concat(answerString);
        Debug.Log("-"+output+"-");
        output = string.Concat(inputStrings);
        Debug.Log("-"+output+"-");
        if (string.Compare(answerString, string.Concat(inputStrings)) == 0)
        {
            outputText.text = ">compiling...\n>build successful\n>press q to exit";
            currentCompiler.GetComponent<OpenCompilerFromCollider>().solved = true;
            currentCompiler.GetComponent<OpenCompilerFromCollider>().ProgressUpdate();
        }
        else outputText.text = ">compiling...\n>build failed";
    }
    void Resume()
    {
        screen.SetActive(false);
        Time.timeScale = 1;
        paused = false;

    }
    void Pause()
    {
        
        screen.SetActive(true);
        Time.timeScale = 0;
        paused = true;

    }

}
