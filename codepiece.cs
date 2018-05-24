using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codepiece : MonoBehaviour {

    public string pstatus = "idle";
    public string checkp = "";
    public KeyCode placep = KeyCode.Mouse1;

	void Update () 
    {
        if (pstatus == "pickedup")
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.WorldToScreenPoint(mousePosition);
            transform.position = objPosition;
        }

        if (Input.GetKeyDown(placep))
        {
            checkp = "y";
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.name == "pos1") && (checkp=="y"))
        {
            transform.position = other.gameObject.transform.position;
            pstatus = "locked";
            checkp = "n";
        }
        else if ((other.gameObject.name == "pos2") && (checkp == "y"))
        {
            transform.position = other.gameObject.transform.position;
            pstatus = "locked";
            checkp = "n";
        }
        else if ((other.gameObject.name == "pos3") && (checkp == "y"))
        {
            transform.position = other.gameObject.transform.position;
            pstatus = "locked";
            checkp = "n";
        }
        else if ((other.gameObject.name == "pos4") && (checkp == "y"))
        {
            transform.position = other.gameObject.transform.position;
            pstatus = "locked";
            checkp = "n";
        }
        else if ((other.gameObject.name == "pos5") && (checkp == "y"))
        {
            transform.position = other.gameObject.transform.position;
            pstatus = "locked";
            checkp = "n";
        }
        else if ((other.gameObject.name == "pos6") && (checkp == "y"))
        {
            transform.position = other.gameObject.transform.position;
            pstatus = "locked";
            checkp = "n";
        }
        else if ((other.gameObject.name == "pos7") && (checkp == "y"))
        {
            transform.position = other.gameObject.transform.position;
            pstatus = "locked";
            checkp = "n";
        }
        else if ((other.gameObject.name == "pos8") && (checkp == "y"))
        {
            transform.position = other.gameObject.transform.position;
            pstatus = "locked";
            checkp = "n";
        }
    }

    private void OnMouseDown()
    {
        pstatus = "pickedup";
    }
}
