using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour {
	
	public static bool isPaused = true;

	void getkey() {	
		if (isPaused == true || Time.timeScale == 1)
			isPaused = false;
		else
			isPaused = true;
	}

	public void pause(){
		getkey ();
		if(isPaused==false) {
			Time.timeScale = 0;
		}
		if(isPaused==true) {
			Time.timeScale = 1;
		}

	}
}