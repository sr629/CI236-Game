using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compiler {
	public String p1 = null; //each placeholder is a string variable to take in value of operator name
	public String p2 = null;
	public String p3 = null;
	public String p4 = null;
	public String p5 = null;
	public String p6 = null;
	public String p7 = null;
	public String p8 = null;
	public boolean instance1; // boolean for if the instance is correctly assigned to place holders
	public boolean instance2;
	public boolean instance3;
	public boolean instance4;


	public void readIn () {
		Scanner placeHolders;
		placeHolders = new Scanner(System.in);
		
		p1 = placeHolders.next();
		p2 = placeHolders.next();
		p3 = placeHolders.next();
		p4 = placeHolders.next();
		p5 = placeHolders.next();
		p6 = placeHolders.next();
		p7 = placeHolders.next();
		p8 = placeHolders.next();
	}

public String cases () {
        if ((p1 == "while") && (p2 == "press") && (p3 == "button") && (p4 == "then") && (p5 == "dash") && (p6 == null) && (p7 == null) && (p8 == null)) {
		//return that code
		instance1 = true;
        } else if ((p1 == "while") && (p2 == "press") && (p3 == "button") && (p4 == "then") && (p5 == "attack") && (p6 == null) && (p7 == null) && (p8 == null))
        {
		// return that code
		instance2 = true;
        } else if ((p1 == "while") && (p2 == "press") && (p3 == "button") && (p4 == "then") && (p5 == "dash") && (p6 == "variable[]") && (p7. == "times") && (p8 == null)) {
		// return that code
		instance3 = true;
        } else if ((p1 == "while") && (p2 == "press") && (p3 == "button") && (p4 == "then") && (p5. == "attack") && (p6. == "variable[]") && (p7 == "times") && (p8 == (null)) {
		// return that code
		instance4 = true;
	} else {
		return "incorrect";
	}
	return "incorrect";
}


public String runCode () {
	if (instance1 = true) {
		//do script for dash
	} else if (instance2 = true) {
		// do script for attack
	} else if (instance3 = true) {
		// do script for dash burst
	} else if (instance4 = true) {
		// do script for attack burst
	} else {
		return "error";
	}
	return "error";
}
}

