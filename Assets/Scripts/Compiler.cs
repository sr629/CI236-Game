using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compiler : MonoBehaviour {

    private Transform[] cells;
    public string[] puzzle;

	// Use this for initialization
	
	// Update is called once per frame
	
    public void CheckPuzzle()
    {
        cells = GetComponentsInChildren<Transform>();
        string input="";
        foreach (Transform cell in cells)
        {
            
            if (cell.tag=="Module")
            {
                input += cell.name; 
            }

        }
        string answer = "";
        foreach (string module in puzzle)
        {
            if ( module != null )answer += module;
        }
        if (input == answer)
        {
            Debug.Log("Success");
        }
        else Debug.Log("Fail" + "\n" + input + "\n" + answer);

    }
}
