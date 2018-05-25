using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCompilerFromCollider : MonoBehaviour {


    private GameObject popup;
    private TriggerCompiler compilerScript;
    public int puzzleIndex;
    public bool solved=false;
    public string[] codeBlocks;
    public string[] answer;
    
    private void Start()
    {
        compilerScript = GameObject.FindObjectOfType<TriggerCompiler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            compilerScript.OpenCloseText(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            
            compilerScript.OpenCloseText(false);
            compilerScript.OpenCompiler();
            compilerScript.SetupCompiler(codeBlocks,answer,this.gameObject);
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            compilerScript.OpenCloseText(false);
        }
    }
    public void ProgressUpdate()
    {
        if (solved)
        {
            GameMaster.Instance.UpdateProgress(puzzleIndex);
        }
    }
}
